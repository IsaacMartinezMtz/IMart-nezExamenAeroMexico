using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ReservacionesController : Controller
    {
        // GET: Reservaciones
        public ActionResult GetAll()
        {
            return View();
        }
    }
}