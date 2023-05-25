using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ParcialOptativo.Model;

namespace ParcialOptativo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesCuentaController : Controller
    {
        private readonly string _connectionString = "";
        //private Npgsql.NpgsqlConnection connection;
        public OperacionesCuentaController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        private string monto = "";
        private string idCuenta = "";

        [HttpPost("depositar")]
        public IActionResult Depositar([FromBody] CuentaModel cuenta, int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var cuentaExistente = connection.ExecuteScalar<int>(
                    " select count(*) from cuenta where id = @id", new { Id = idCuenta }
                );

                if (cuentaExistente == 0)
                {
                    return NotFound("Cuenta no encontrada.");


                    connection.Execute("update cuenta set saldo = saldo + @cuenta where id = @id", new { cuenta = monto, id = idCuenta });
                }

                return Ok("Depósito realizado con éxito.");
            }
        }

        [HttpPost("transferir")]
        public IActionResult Transferir([FromBody] CuentaModel cuenta)
        {
            return Ok("Transferencia realizada con éxito.");
        }

        [HttpPost("bloquear")]
        public IActionResult Bloquear([FromBody] CuentaModel cuenta)
        {
            return Ok("Cuenta bloqueada con éxito.");
        }

        [HttpGet("imprimirExtracto")]
        public IActionResult ImprimirExtracto(int idCuenta)
        {
            return Ok("Extracto impreso con éxito");
        }
        
        [HttpPost("retirar")]
        public IActionResult retirar(int idCuenta)
        {
            return Ok("El retiro se realizó con éxito");
        }
    }
}
