using Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ParcialOptativo.Model;
using Services.Services;

namespace ParcialOptativo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OperacionesCuentaController : Controller
    {
        private OperacionesCuentaService operacionesCuentaService;

        public OperacionesCuentaController(OperacionesCuentaService operacionCuentaService)
        {
            this.operacionesCuentaService = operacionCuentaService;
        }

        [HttpPut("{idCuentaOriginal}/Transferir/{idCuentaDestino}")]
        public ActionResult Transferir(int idCuentaOriginal, int idCuentaDestino, double monto)
        {
            try
            {
                var resultado = operacionesCuentaService.Transferir(idCuentaOriginal, idCuentaDestino, monto);
               
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred" + ex);
            }

        }

        [HttpPut("Depositar/{idCuentaOriginal}")]
        public ActionResult Depositar(int idCuentaOriginal, double monto)
        {
            try
            {
                var resultado = operacionesCuentaService.Depositar(idCuentaOriginal, monto);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPut("Extraer/{idCuentaOriginal}")]
        public ActionResult Extraer(double monto, int idCuentaOriginal)
        {
            try
            {
                var resultado = operacionesCuentaService.Extraer(monto, idCuentaOriginal);
                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpDelete("Bloquear/{idCuentaOriginal}")]
        public ActionResult Bloquear(int idCuentaOriginal)
        {
            try
            {
                var resultado = operacionesCuentaService.Bloquear(idCuentaOriginal);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }

        [HttpPost("Imprimir/{idCuentaOriginal}")]
        public ActionResult Imprimir(int idCuentaOriginal)
        {
            try
            {
                var resultado = operacionesCuentaService.Imprimir(idCuentaOriginal);

                return Ok(resultado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred");
            }
        }
    }
}
