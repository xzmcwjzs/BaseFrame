using ntu.xzmcwjzs.DAL.Repositories;
using ntu.xzmcwjzs.IDAL.IRepositories;
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
        private static readonly string AssemblyPath = ConfigurationManager.AppSettings["AssemblyPath"];
        private static readonly string NameSpacePath = ConfigurationManager.AppSettings["NameSpacePath"];

        //public static ITestRepository GetTestRepository()
        //{
        //    return Assembly.Load(AssemblyPath).CreateInstance(NameSpacePath + ".Repositories.TestRepository") as TestRepository;
        //}
    }
}
