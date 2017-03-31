 
  
  
  
  
  

using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.BLL.Services
{
 		
	  public partial class ArticleService:BaseService<Article>,IArticleService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.IArticleRepository;
        }
    }
		
	  public partial class SearchDetailService:BaseService<SearchDetail>,ISearchDetailService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISearchDetailRepository;
        }
    }
		
	  public partial class SearchTotalService:BaseService<SearchTotal>,ISearchTotalService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ISearchTotalRepository;
        }
    }
		
	  public partial class TestService:BaseService<Test>,ITestService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ITestRepository;
        }
    }
}