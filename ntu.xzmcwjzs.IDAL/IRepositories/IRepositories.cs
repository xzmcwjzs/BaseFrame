 
  
  
  
  
  
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.IDAL.IRepositories
{
		
	 public partial  interface IArticleRepository:IBaseRepository<Article>
    {
    }
		
	 public partial  interface ISearchDetailRepository:IBaseRepository<SearchDetail>
    {
    }
		
	 public partial  interface ISearchTotalRepository:IBaseRepository<SearchTotal>
    {
    }
		
	 public partial  interface ITestRepository:IBaseRepository<Test>
    {
    }
}