using ntu.xzmcwjzs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ntu.xzmcwjzs.Model.Entities;

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
        public JsonResult GetList(GridPager pager)
        { 
            var list = testService.GetList(ref pager);
            var json = new
            {
                total = pager.totalRows,
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
        #region 创建
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Test model)
        {


            if (testService.AddEntity(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 修改

        public ActionResult Edit(string id)
        {
           Int32 i = Convert.ToInt32(id);
            Test entity = testService.LoadEntities(t=>t.id==i).FirstOrDefault(); 
            return View(entity);
        }

        [HttpPost]

        public JsonResult Edit(Test model)
        {


            if (testService.UpdateEntity(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 详细
        public ActionResult Details(string id)
        {
            Int32 i = Convert.ToInt32(id);
            Test entity = testService.LoadEntities(t => t.id == i).FirstOrDefault();
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
           
            if (!string.IsNullOrWhiteSpace(id))
            {
                Int32 i = Convert.ToInt32(id);
                if (testService.DeleteByLambda(t=>t.id==i))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            } 
        }
        #endregion

    }

}