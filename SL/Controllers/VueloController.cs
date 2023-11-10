using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    [RoutePrefix("api/vuelo")]
    public class VueloController : ApiController
    {
        [Route("busqueda/{FechaInicio?}/{FechaFin?}")]
        [HttpGet]
        public IHttpActionResult Busqueda(DateTime FechaInicio, DateTime FechaFin)
        {
            ML.Result result = BL.Vuelo.BusquedaVuelos(FechaInicio, FechaFin);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("ListaVuelos")]
        [HttpGet]
        public IHttpActionResult ListaVuelos()
        {
            ML.Result result = BL.Vuelo.LisGVuelos();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
        [Route("Destino/{Destino?}")]
        [HttpGet]
        public IHttpActionResult GetDestino(string destino) {
            ML.Result result = BL.Vuelo.GetDestino(destino);
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
