using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParcialOptativo.Model;
using Services.Services;

namespace ParcialOptativo.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private ClienteService clienteService;
        private IConfiguration configuration;

        public ClienteController(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.clienteService = new ClienteService(configuration.GetConnectionString("postgresDB"));
        }

        [HttpGet("ListarCliente")]
        public ActionResult<List<ClienteModel>> ListarClientes()
        {
            var resultado = clienteService.listarCliente();
            return Ok(resultado);
        }

        [HttpGet("ConsultarCliente/{id}")]
        public ActionResult<ClienteModel> ConsultarCliente(int id)
        {
            var resultado = this.clienteService.consultarCliente(id);
            return Ok(resultado);
        }

        [HttpPost("InsertarCliente")]
        public ActionResult<string> insertarCliente(ClienteModel modelo)
        {
            var resultado = this.clienteService.insertarCliente(new Infraestructure.Models.ClienteModel
            {
                nombre = modelo.nombre,
                apellido = modelo.apellido,
                email = modelo.email,
                telefono = modelo.telefono,
                nacionalidad = modelo.nacionalidad,
                ciudad = modelo.ciudad,
                documentoNum = modelo.documentoNum,
                fechaNacimiento = modelo.fechaNacimiento,
                idCiudad = modelo.idCiudad,
                
            });
            return Ok(resultado);
        }

        [HttpPut("modificarCliente/{id}")]
        public ActionResult<string> modificarCliente(ClienteModel modelo, int id)
        {
            var resultado = this.clienteService.modificarCliente(new Infraestructure.Models.ClienteModel
            {
                nombre = modelo.nombre,
                apellido = modelo.apellido,
                email = modelo.email,
                telefono = modelo.telefono,
                nacionalidad = modelo.nacionalidad,
                ciudad = modelo.ciudad,
                documentoNum = modelo.documentoNum,
                fechaNacimiento = modelo.fechaNacimiento,
                idCiudad = modelo.idCiudad,
            }, id);
            return Ok(resultado);
        }

        [HttpDelete("eliminarCliente/{id}")]
        public ActionResult<string> eliminarCliente(int id)
        {
            var resultado = this.clienteService.eliminarCliente(id);
            return Ok(resultado);
        }
    }
}

