 
  
  
  
  
  
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
   		
	 ITestRepository ITestRepository{get;set;}
    }
}