using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ntu.xzmcwjzs.BLL.Services
{
    public partial class SysModuleService : BaseService<SysModule>, ISysModuleService
    {
        public List<SysModule> GetMenuByPersonId(string moduleId)
        {
            var list = repository.LoadEntities(t => true).ToList();
            var menus =
            (
                from m in list
                where m.ParentId == moduleId
                where m.Id != "0"
                select m
                      ).Distinct().OrderBy(a => a.Sort).ToList();
            return menus;

        }
    }
}
