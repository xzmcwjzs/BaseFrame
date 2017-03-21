using ntu.xzmcwjzs.DAL.Repositories;
using ntu.xzmcwjzs.IDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.DALSessionFactory
{
  public  class RepositoryIoc
    {
        private static ITestRepository _TestRepository;
        public RepositoryIoc(ITestRepository TestRepository)
        {
             _TestRepository = TestRepository;
        }
        public static ITestRepository GetTestRepository()
        {
            return _TestRepository;
        }
    }
}
