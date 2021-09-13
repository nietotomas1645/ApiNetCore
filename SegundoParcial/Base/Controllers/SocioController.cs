using System;
using System.Linq;
using Resultados;
using Base.Comandos.Socios;
using Base.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace Base.Controllers
{
    [ApiController] 
    [EnableCors("Prog3")]   
    public class SocioController:ControllerBase
    {   
        private readonly ILogger<SocioController> _logger;
        private readonly parcialProg3SociosContext db = new parcialProg3SociosContext();
        [HttpPost]
        [Route("Socios/CrearSocio")]
        public ActionResult<ResultadoAPI> PostSocio([FromBody]ComandoInsertSocio comando)
        {
            var resultado = new ResultadoAPI();
            if(comando.Nombre.Equals("")){
                resultado.Ok=false;
                resultado.Error= "Ingrese nombre";
                return resultado;
            }
             if(comando.Apellido.Equals("")){
                resultado.Ok=false;
                resultado.Error= "Ingrese Apellido";
                return resultado;
            }
             if(comando.Calle.Equals("")){
                resultado.Ok=false;
                resultado.Error= "Ingrese Calle";
                return resultado;
            }

             if(comando.Numero.Equals("")){
                resultado.Ok=false;
                resultado.Error= "Ingrese Numero";
                return resultado;
            }
             if(comando.IdDeporte.Equals("")){
                resultado.Ok=false;
                resultado.Error= "Seleccione un Deporte";
                return resultado;
            }

            var socio = new Socio();
            socio.Nombre= comando.Nombre;
            socio.Apellido= comando.Apellido;
            socio.Calle= comando.Calle;
            socio.Numero=comando.Numero;
            socio.IdDeporte= comando.IdDeporte;

            db.Socios.Add(socio);
            db.SaveChanges();
            resultado.Ok= true;
            resultado.Return = db.Socios.ToList();
            return resultado;
        }

        [HttpGet]
        [Route("Socios/ObtenerDeportes")]
        public ActionResult<ResultadoAPI> getDeporte()
        {
            var resultado= new ResultadoAPI();
            try
            {
                resultado.Ok= true;
                resultado.Return= db.Deportes.ToList();

                return resultado;
            }
            catch(Exception ex)
            {
                resultado.Ok= false;
                resultado.CodigoError=1;
                resultado.Error= "Error al cargar los Deportes";

                return resultado;
            }
        }
    }
}
