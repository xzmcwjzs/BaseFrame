using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ntu.xzmcwjzs.WebApp.Controllers
{
    public class TestController : Controller
    {
        private readonly IBLL.IServices.ITestService testService;
        public TestController(IBLL.IServices.ITestService testService)
        {
            this.testService = testService;
        }
        public ActionResult Index()
        { 
            return View();
        }
        [HttpPost]
        public JsonResult GetList()
        {
            var list = testService.LoadEntityAsNoTracking(t => true).ToList();
            var json = new
            {
                total = list.Count,
                rows = (from t in list
                        select new Model.Entities.Test()
                        {

                            id = t.id,
                            name = t.name,
                            password=t.password,
                            id_card_num=t.id_card_num,
                            birthdate=t.birthdate,
                            photo=t.photo,
                            createtime=t.createtime
                        }).ToArray()
            };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}