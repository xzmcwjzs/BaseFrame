using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities; 

namespace ntu.xzmcwjzs.WebApp.Controllers
{
    public class HomeController : Controller
    {
       private readonly ISysModuleService sysModuleService;
       public HomeController(ISysModuleService sysModuleService)
        {
            this.sysModuleService = sysModuleService;
        }
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 获取导航菜单
        /// </summary>
        /// <param name="id">所属</param>
        /// <returns>树</returns>
        public JsonResult GetTree(string id)
        {

            List<SysModule> menus = sysModuleService.GetMenuByPersonId(id);
            var jsonData = (
                    from m in menus
                    select new
                    {
                        id = m.Id,
                        text = m.Name,
                        value = m.Url,
                        showcheck = false,
                        complete = false,
                        isexpand = false,
                        checkstate = 0,
                        hasChildren = m.IsLast ? false : true,
                        Icon = m.Iconic
                    }
                ).ToArray();
            return Json(jsonData, JsonRequestBehavior.AllowGet); 
        } 
    }
}