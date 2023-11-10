using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Reservaciones
    {
        public static ML.Result Add(ML.Reservaciones reservaciones) {
        ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezAereomexicoEntities contexr = new DL.IMartinezAereomexicoEntities())
                {
                    var query = contexr.AddReservacion(reservaciones.Usuario.IdUsuario, reservaciones.Vuelos.IdVuelos);
                    if(query > 0)
                    {
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }

                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        } 
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezAereomexicoEntities context = new DL.IMartinezAereomexicoEntities())
                {
                    var query = context.GetAllVuelos().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Reservaciones reservaciones = new ML.Reservaciones();
                            reservaciones.IdReservaciones = obj.IdReservacion;
                            reservaciones.Vuelos = new ML.Vuelos();
                            reservaciones.Usuario = new ML.Usuario();
                            reservaciones.Usuario.Nombre = obj.Nombre;
                            reservaciones.Usuario.ApelliodPaterno = obj.ApellidoPaterno;
                            reservaciones.Vuelos.NumeroVuelo = obj.NumeroVuelo;
                            reservaciones.Vuelos.Origen = obj.Origen;
                            reservaciones.Vuelos.Destino = obj.Destino;
                            reservaciones.Vuelos.FechaSalida = (DateTime)obj.FechaSalida;

                            result.Objects.Add(reservaciones);

                        }
                        result.Correct = true;
                    }
                    else {
                        result.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;

        }
    }
}
