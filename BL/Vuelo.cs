using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Vuelo
    {
        public static ML.Result BusquedaVuelos(DateTime FechaInicio, DateTime FechaFin)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezAereomexicoEntities context = new DL.IMartinezAereomexicoEntities())
                {
                    var query = context.BusquedaVuelos(FechaInicio, FechaFin).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var obj in query)
                        {
                            ML.Vuelos vueloB = new ML.Vuelos();
                            vueloB.IdVuelos = obj.IdVuelos;
                            vueloB.NumeroVuelo = obj.NumeroVuelo;
                            vueloB.Origen = obj.Origen;
                            vueloB.Destino = obj.Destino;
                            vueloB.FechaSalida = (DateTime)obj.FechaSalida;
                            result.Objects.Add(vueloB);
                        }
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
            return  result;
        }
        public static ML.Result LisGVuelos()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.IMartinezAereomexicoEntities context = new DL.IMartinezAereomexicoEntities())
                {
                    var query = context.LisGVuelos();
                    if(query != null)
                    {
                        result.Objects = new List<object>();

                        foreach(var obj in query)
                        {
                            ML.Vuelos vuelos = new ML.Vuelos();
                            vuelos.IdVuelos = obj.IdVuelos;
                            vuelos.Destino = obj.Destino;
                            vuelos.FechaSalida = (DateTime)obj.FechaSalida;
                            result.Objects.Add(vuelos);

                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetDestino(string destino)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IMartinezAereomexicoEntities context = new DL.IMartinezAereomexicoEntities())
                {
                    var query = context.GetDestino(destino);
                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach(var obj in query)
                        {
                            ML.Vuelos vuelos = new ML.Vuelos();
                            vuelos.IdVuelos = obj.IdVuelos;
                            vuelos.FechaSalida = (DateTime)obj.FechaSalida;

                            result.Objects.Add(vuelos);
                        }
                        result.Correct= true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
