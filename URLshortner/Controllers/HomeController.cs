using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using URLshortner.Models;

namespace URLshortner.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetShortURL(string longURL)
        {
            Model obj = new Model();
            return Json(obj.ConvertNSave(longURL));
        }

        public ActionResult GetOriginalURL(string shortURL)
        {
            Model obj = new Model();
            return Json(obj.ReadNExtract(shortURL));
        }
    }
}