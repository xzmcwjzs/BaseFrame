 
  
  
  
  
  

using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.IBLL.IServices
{
 		
	public partial interface IArticleService : IBaseService<Article>
    {
    }
		
	public partial interface ISearchDetailService : IBaseService<SearchDetail>
    {
    }
		
	public partial interface ISearchTotalService : IBaseService<SearchTotal>
    {
    }
		
	public partial interface ITestService : IBaseService<Test>
    {
    }
}