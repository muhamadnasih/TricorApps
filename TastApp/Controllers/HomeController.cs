using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TastApp.Models;


namespace TastApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITodoProcessor todo;
        public HomeController()
        {
            
        }
        public ActionResult Index()
        {
            return View();
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

        public ActionResult Todo()
        {
            ViewBag.Message = "Your to do page.";

            return View();
        }

        public ActionResult Todo(TodoViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
        
        }

    }
}