using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WritingTutor.Web.Service;

namespace WritingTutor.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService _homeService;

        public HomeController(IHomeService homeService) {
            _homeService = homeService;
        }
        public ActionResult Index()
        {
            ViewBag.Name = _homeService.GetName();
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
    }
}