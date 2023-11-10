using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class VueloController : Controller
    {
        // GET: Vuelo
        public ActionResult GetAll()
        {
            return View();
        }
    }
}