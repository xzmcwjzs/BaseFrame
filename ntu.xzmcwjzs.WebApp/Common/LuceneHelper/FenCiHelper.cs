using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;
using PanGu;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace ntu.xzmcwjzs.WebApp.Common.LuceneHelper
{
    public class FenCiHelper
    {
        public static List<string> PanGuSplitWord(string msg)
        {
            Analyzer analyzer = new PanGuAnalyzer();
            StringReader r = new StringReader(msg);
            TokenStream ts = analyzer.TokenStream("", r);
            ITermAttribute termAtt = ts.GetAttribute<ITermAttribute>();
            List<string> list = new List<string>();
            while (ts.IncrementToken())
            {
                string iterm = termAtt.Term;
                list.Add(iterm);
            }
            return list;
        }

        // /创建HTMLFormatter,参数为高亮单词的前后缀
        public static string CreateHightLight(string keywords, string Content)
        {
            PanGu.HighLight.SimpleHTMLFormatter simpleHTMLFormatter =
             new PanGu.HighLight.SimpleHTMLFormatter("<font color=\"red\">", "</font>");
            //创建Highlighter ，输入HTMLFormatter 和盘古分词对象Semgent
            PanGu.HighLight.Highlighter highlighter =
            new PanGu.HighLight.Highlighter(simpleHTMLFormatter,
            new Segment());
            //设置每个摘要段的字符数
            highlighter.FragmentSize = 150;
            //获取最匹配的摘要段
            return highlighter.GetBestFragment(keywords, Content);

        }
    }
}