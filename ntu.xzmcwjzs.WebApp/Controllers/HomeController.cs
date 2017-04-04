using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.Model.Entities;
using ntu.xzmcwjzs.Model.ViewModel;

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

            List<TreeViewModel>nodeList = sysModuleService.ToTreeNodesByPid(id);
            //foreach (var item in menus)
            //{
            //    if (!item.IsLast) {
            //        List<SysModule> children = sysModuleService.GetMenuByPersonId(item.Id);
            //    }
            //} 
            var jsonData = (
                    from m in nodeList
                    select new
                    {
                        id = m.id,
                        text = m.text,
                        children=m.children,
                        state=m.state, 
                        url = m.url, 
                        icon = m.icon
                    }
                ).ToArray();


            return Json(jsonData, JsonRequestBehavior.AllowGet); 
        } 
    }
}