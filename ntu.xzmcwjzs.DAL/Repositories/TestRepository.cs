using ntu.xzmcwjzs.IDAL.IRepositories;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.DAL.Repositories
{
   public partial class TestRepository:BaseRepository<Test>,ITestRepository
    {

    }
}
