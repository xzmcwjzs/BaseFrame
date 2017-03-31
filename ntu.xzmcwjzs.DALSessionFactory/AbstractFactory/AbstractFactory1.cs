 
  
  
  
  
 
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
 	    public static ArticleRepository GetArticleRepository()
		    {
		        return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.ArticleRepository") as 

ArticleRepository;
		    }
	  	    public static SearchDetailRepository GetSearchDetailRepository()
		    {
		        return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.SearchDetailRepository") as 

SearchDetailRepository;
		    }
	  	    public static SearchTotalRepository GetSearchTotalRepository()
		    {
		        return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.SearchTotalRepository") as 

SearchTotalRepository;
		    }
	  	    public static TestRepository GetTestRepository()
		    {
		        return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.TestRepository") as 

TestRepository;
		    }
	   
   }
}