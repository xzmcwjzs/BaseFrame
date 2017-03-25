 
  
  
  
  
  

using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.BLL.Services
{
 		
	  public partial class TestService:BaseService<Test>,ITestService
    {
        public override void SetCurretnRepository()
        {
            CurrentRepository = this.GetCurrentDbSession.ITestRepository;
        }
    }
}