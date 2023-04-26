using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure.Models;
using Dapper;


namespace Infraestructure.Repository
{
    public class ClienteRepository
    {

        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public ClienteRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarCliente(ClienteModel cliente)
        {
            try
            {
                connection.Execute("insert into cliente(nombre, apellido, email, telefono, documentonum, nacionalidad," +
                    "fechanacimiento, ciudad, idciudad) " +
                    " values(@nombre, @apellido, @email, @telefono, @documentonum, @nacionalidad," +
                    "@fechanacimiento, @ciudad, @idciudad)", cliente);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarCliente(ClienteModel cliente, int id)
        {
            try
            {
                connection.Execute($"UPDATE cliente SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "email = @email, " +
                    "telefono = @telefono, " +
                    "documentonum = @documentonum" +
                    "nacionalidad = @nacionalidad" +
                    "fechanacimiento = @fechanacimiento" +
                    "ciudad = @ciudad" +
                    $"WHERE id = {id}", cliente);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarCliente(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM cliente WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClienteModel consultarCliente(int id)
        {
            try
            {
                return connection.QueryFirst<ClienteModel>($"SELECT * FROM cliente WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ClienteModel> listarCliente()
        {
            try
            {
                return connection.Query<ClienteModel>($"SELECT * FROM cliente order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}
