using AspectIct.KnowledgeBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspectIct.KnowledgeBase.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Web API HomePage";
            var model = new HomeViewModel();
            model.Name = "Aspect-ICT";
            model.Address = "Hardinxveld-Giessendam";

            return View(model);
        }
    }
}
