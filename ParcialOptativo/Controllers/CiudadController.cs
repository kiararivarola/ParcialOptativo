using Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Services;

namespace ParcialOptativo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CiudadController : ControllerBase
    {

        private CiudadService ciudadService;
        private IConfiguration configuration;

        public CiudadController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.ciudadService = new CiudadService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ListarCiudad")]
        public ActionResult<List<CiudadModel>> ListarCiudad()
        {
            var resultado = ciudadService.listarCiudad();
            return Ok(resultado);
        }

        [HttpGet("ConsultarCiudad/{id}")]
        public ActionResult<CiudadModel> ConsultarCiudad(int id)
        {
            var resultado = this.ciudadService.consultarCiudad(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCiudad")]
        public ActionResult<string> insertarCiudad(CiudadModel modelo)
        {
            var resultado = this.ciudadService.insertarCiudad(new Infraestructure.Models.CiudadModel
            {
                ciudad = modelo.ciudad,
                estado = modelo.estado,
            });
            return Ok(resultado);
        }

        [HttpPut("modificarCiudad/{id}")]
        public ActionResult<string> modificarCiudad(CiudadModel modelo, int id)
        {
            var resultado = this.ciudadService.modificarCiudad(new Infraestructure.Models.CiudadModel
            {
                ciudad = modelo.ciudad,
                estado = modelo.estado,
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCiudad/{id}")]
        public ActionResult<string> eliminarCiudad(int id)
        {
            var resultado = this.ciudadService.eliminarCiudad(id);
            return Ok(resultado);
        }
    }
}
