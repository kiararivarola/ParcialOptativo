using Dapper;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class OperacionesCuentaRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public OperacionesCuentaRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }
        public string depositar(CuentaModel cuenta)
        {
            try
            {
                connection.Execute(" insert into cuenta "
                    + "(saldo) "
                    + " values (@saldo)", cuenta);
                return "Se depositó correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
