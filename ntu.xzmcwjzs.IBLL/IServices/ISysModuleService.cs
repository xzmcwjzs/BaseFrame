using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.IBLL.IServices
{
    public partial interface ISysModuleService : IBaseService<SysModule>
    {
        List<SysModule> GetMenuByPersonId(string moduleId);
    }
}
