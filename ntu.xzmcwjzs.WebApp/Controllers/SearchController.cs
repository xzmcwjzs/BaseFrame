﻿using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using Lucene.Net.Search;
using ntu.xzmcwjzs.WebApp.Common.LuceneHelper;

namespace ntu.xzmcwjzs.WebApp.Controllers
{
    public class SearchController : Controller
    {
        private readonly IArticleService articleService;
        private readonly ISearchDetailService searchDetailService;
        private readonly ISearchTotalService searchTotalService;
        public SearchController(IArticleService articleService, ISearchDetailService searchDetailService,ISearchTotalService searchTotalService)
        {
            this.articleService = articleService;
            this.searchDetailService = searchDetailService;
            this.searchTotalService = searchTotalService;
        }
        public ActionResult Index()
        {
            var keyWords = searchTotalService.LoadEntities(t => true).OrderByDescending(t => t.SearchCounts).Select(t => t.KeyWords).Skip(0).Take(5).ToList(); 
             ViewBag.KeyWords = keyWords;
            return View();
        }

        public ActionResult SearchContent()
        {
            if (!string.IsNullOrEmpty(Request["btnSearch"]))
            {
               List<Model.ViewModel.FenCiViewModel> list= ShowSearchContent();
                ViewData["list"] = list;
                var keyWords = searchTotalService.LoadEntities(t => true).OrderByDescending(t => t.SearchCounts).Select(t => t.KeyWords).Skip(0).Take(5).ToList();
                ViewBag.KeyWords = keyWords;
                return View("Index");
            }
            else
            {
                CreateSearchContent();
            }
            return Content("ok");
        }

        private void CreateSearchContent()
        {
            string indexPath = @"C:\Lucenedir";//注意和磁盘上文件夹的大小写一致，否则会报错。将创建的分词内容放在该目录下。写到配置文件中
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());//指定索引文件(打开索引目录) FS指的是就是FileSystem
            bool isUpdate = IndexReader.IndexExists(directory);//IndexReader:对索引进行读取的类。该语句的作用：判断索引库文件夹是否存在以及索引特征文件是否存在。
            if (isUpdate)
            {
                //同时只能有一段代码对索引库进行写操作。当使用IndexWriter打开directory时会自动对索引库文件上锁。
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁（提示一下：如果我现在正在写着已经加锁了，但是还没有写完，这时候又来一个请求，那么不就解锁了吗？这个问题后面会解决）
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);//向索引库中写索引。这时在这里加锁。
            List<Article> list = articleService.LoadEntities(t => true).ToList();
            foreach (var item in list)
            {
                Document document = new Document();//表示一篇文档。
                //Field.Store.YES:表示是否存储原值。只有当Field.Store.YES在后面才能用doc.Get("number")取出值来.Field.Index. NOT_ANALYZED:不进行分词保存
                document.Add(new Field("Id", item.ArticleId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                //Field.Index. ANALYZED:进行分词保存:也就是要进行全文的字段要设置分词 保存（因为要进行模糊查询）

                //Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS:不仅保存分词还保存分词的距离。
                document.Add(new Field("Title", item.Title, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                document.Add(new Field("Content", item.Content, Field.Store.YES, Field.Index.ANALYZED, Lucene.Net.Documents.Field.TermVector.WITH_POSITIONS_OFFSETS));
                writer.AddDocument(document);
            }


            writer.Dispose();//会自动解锁。
            directory.Dispose();//不要忘了Close，否则索引结果搜不到

        }

        private List<Model.ViewModel.FenCiViewModel> ShowSearchContent()
        {
            string indexPath = @"C:\Lucenedir";
            List<string> list =FenCiHelper.PanGuSplitWord(Request["txtSearch"]);//对用户输入的搜索条件进行拆分。
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            //搜索条件
            PhraseQuery query = new PhraseQuery();
            foreach (string word in list)//先用空格，让用户去分词，空格分隔的就是词“计算机   专业”
            {
                query.Add(new Term("Content", word));
            }
            //query.Add(new Term("body","语言"));--可以添加查询条件，两者是add关系.顺序没有关系.
            // query.Add(new Term("body", "大学生"));
            //query.Add(new Term("body", kw));//body中含有kw的文章 
            query.Slop = 100;//多个查询条件的词之间的最大距离.在文章中相隔太远 也就无意义.（例如 “大学生”这个查询条件和"简历"这个查询条件之间如果间隔的词太多也就没有意义了。）
            //TopScoreDocCollector是盛放查询结果的容器
            TopScoreDocCollector collector = TopScoreDocCollector.Create(1000, true);
            searcher.Search(query, null, collector);//根据query查询条件进行查询，查询结果放入collector容器
            ScoreDoc[] docs = collector.TopDocs(0, collector.TotalHits).ScoreDocs;//得到所有查询结果中的文档,GetTotalHits():表示总条数   TopDocs(300, 20);//表示得到300（从300开始），到320（结束）的文档内容.
            //可以用来实现分页功能
            List<Model.ViewModel.FenCiViewModel> viewModelList = new List<Model.ViewModel.FenCiViewModel>();
            for (int i = 0; i < docs.Length; i++)
            {
                //
                //搜索ScoreDoc[]只能获得文档的id,这样不会把查询结果的Document一次性加载到内存中。降低了内存压力，需要获得文档的详细内容的时候通过searcher.Doc来根据文档id来获得文档的详细内容对象Document.
                Model.ViewModel.FenCiViewModel viewModel = new Model.ViewModel.FenCiViewModel();

                int docId = docs[i].Doc;//得到查询结果文档的id（Lucene内部分配的id）
                Document doc = searcher.Doc(docId);//找到文档id对应的文档详细信息

                viewModel.Id = Convert.ToInt32(doc.Get("Id"));
                viewModel.Title = doc.Get("Title");
                viewModel.Content =FenCiHelper.CreateHightLight(Request["txtSearch"], doc.Get("Content"));//将搜索的内容高亮显示

                viewModelList.Add(viewModel);
            }
            //将搜索词插入到明细表中
            SearchDetail model = new SearchDetail { Id = Guid.NewGuid(), KeyWords = Request["txtSearch"], SearchDateTime = DateTime.Now };
            searchDetailService.AddEntity(model);

            return viewModelList;
        }
         
        public ActionResult AutoComplete()
        {
            string keyword = Request["keyword"];
            List<string> list = searchTotalService.LoadEntities(t => t.KeyWords.Contains(keyword)).Select(t => t.KeyWords).ToList();

            return Json(list.ToArray(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult Content()
        {
            return View();
        }
    }
}