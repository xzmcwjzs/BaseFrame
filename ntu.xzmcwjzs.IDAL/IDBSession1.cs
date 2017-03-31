 
  
  
  
  
  
using ntu.xzmcwjzs.IDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.IDAL
{
    public partial interface IDBSession
    {
   		
	 IArticleRepository IArticleRepository{get;set;}
		
	 ISearchDetailRepository ISearchDetailRepository{get;set;}
		
	 ISearchTotalRepository ISearchTotalRepository{get;set;}
		
	 ITestRepository ITestRepository{get;set;}
    }
}