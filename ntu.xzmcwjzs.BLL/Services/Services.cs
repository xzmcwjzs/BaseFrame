 
  
  
  
  
  

using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ntu.xzmcwjzs.IDAL.IRepositories;

namespace ntu.xzmcwjzs.BLL.Services
{
 		
	  public partial class ArticleService:BaseService<Article>,IArticleService
    {
        public IArticleRepository repository;
        public ArticleService(IArticleRepository repository)
        {
            this.repository = repository;
            base.CurrentRepository = repository;
        }
    }
		
	  public partial class SearchDetailService:BaseService<SearchDetail>,ISearchDetailService
    {
        public ISearchDetailRepository repository;
        public SearchDetailService(ISearchDetailRepository repository)
        {
            this.repository = repository;
            base.CurrentRepository = repository;
        }
    }
		
	  public partial class SearchTotalService:BaseService<SearchTotal>,ISearchTotalService
    {
        public ISearchTotalRepository repository;
        public SearchTotalService(ISearchTotalRepository repository)
        {
            this.repository = repository;
            base.CurrentRepository = repository;
        }
    }
		
	  public partial class TestService:BaseService<Test>,ITestService
    {
        public ITestRepository repository;
        public TestService(ITestRepository repository)
        {
            this.repository = repository;
            base.CurrentRepository = repository;
        }
    }
}