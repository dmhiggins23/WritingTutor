using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WritingTutor.Web.Controllers
{
    [Authorize]
    public class EssayController : Controller
    {
        public ActionResult Load(int id) {
            return Content("Loading Essay");
        }
    }
}