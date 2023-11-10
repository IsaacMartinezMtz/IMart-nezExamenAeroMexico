using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/Reservaciones")]
    public class ReservacionesController : ApiController
    {
        [Route("Reservaciones")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Reservaciones.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, result);
            }

        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult add(ML.Reservaciones reservaciones) 
        {
            ML.Result result = BL.Reservaciones.Add(reservaciones);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.InternalServerError, result);
            }
        }
    }
}
