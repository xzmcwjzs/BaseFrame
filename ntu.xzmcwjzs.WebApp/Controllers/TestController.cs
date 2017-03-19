using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ntu.xzmcwjzs.Model.DataBaseContext;
using ntu.xzmcwjzs.Model.Entities;
using ntu.xzmcwjzs.IBLL.IServices;
using ntu.xzmcwjzs.BLL.Services;

namespace ntu.xzmcwjzs.WebApp.Controllers
{
    public class TestController : Controller
    {
        //private XZMCWJZSContext db = new XZMCWJZSContext();
        ITestService service = new TestService();
        // GET: Test
        public ActionResult Index()
        {
            // return View(await db.Test.ToListAsync());
            var list = service.LoadEntities(t => true).ToList();
            return View(list);
        }

       
    }
}
