 
  
  
  
  
  
using ntu.xzmcwjzs.IDAL.IRepositories;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.DAL.Repositories
{
		
	public partial class ArticleRepository:BaseRepository<Article>,IArticleRepository
    {
	}
		
	public partial class SearchDetailRepository:BaseRepository<SearchDetail>,ISearchDetailRepository
    {
	}
		
	public partial class SearchTotalRepository:BaseRepository<SearchTotal>,ISearchTotalRepository
    {
	}
		
	public partial class TestRepository:BaseRepository<Test>,ITestRepository
    {
	}
}