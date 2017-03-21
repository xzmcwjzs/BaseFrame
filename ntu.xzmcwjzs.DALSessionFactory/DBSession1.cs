 
using ntu.xzmcwjzs.DAL;
using ntu.xzmcwjzs.IDAL;
using ntu.xzmcwjzs.IDAL.IRepositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.DALSessionFactory
{
    /// <summary>
    /// DBSession;工厂类（数据会话层），作用：创建数据操作类的实例，业务层通过DBSession调用相应的数据操作类的实例，这样将业务层与数据层解耦。
    /// </summary>
    public partial class DBSession : IDBSession
    {
		
	  private ITestRepository _TestRepository;
        public ITestRepository ITestRepository
        {
            get
            {
                if (_TestRepository == null)
                {
                    _TestRepository = AbstractFactory.GetTestRepository();
                }
                return _TestRepository;
            }
            set { _TestRepository = value; }
        }
    }
}