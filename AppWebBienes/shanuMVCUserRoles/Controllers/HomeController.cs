using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{

    public class HomeController : Controller
	{
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BienesModels
        public ActionResult Index()
        {
            return View(db.BienesModels.ToList().Where(a => a.Activo));
        }

        public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}