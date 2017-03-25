 
  
  
  
  
 
using ntu.xzmcwjzs.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.DALSessionFactory
{
 public partial  class AbstractFactory
    {
 	    public static TestRepository GetTestRepository()
		    {
		        return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.TestRepository") as 

TestRepository;
		    }
	   
   }
}