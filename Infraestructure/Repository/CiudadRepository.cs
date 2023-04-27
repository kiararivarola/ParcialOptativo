﻿using Dapper;
using Infraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Repository
{
    public class CiudadRepository
    {

        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public CiudadRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarCiudad(CiudadModel ciudad)
        {
            try
            {
                connection.Execute("insert into ciudad(ciudad, estado)" +
                    " values(@ciudad, @estado)", ciudad);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarCiudad(CiudadModel ciudad, int id)
        {
            try
            {
                connection.Execute($"UPDATE ciudad SET " +
                    //"id = @id," +
                    "ciudad = @ciudad, " +
                    "estado = @estado " +
                    $"WHERE id = {id}", ciudad);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarCiudad(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM ciudad WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public CiudadModel consultarCiudad(int id)
        {
            try
            {
                return connection.QueryFirst<CiudadModel>($"SELECT * FROM ciudad WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<CiudadModel> listarCiudad()
        {
            try
            {
                return connection.Query<CiudadModel>($"SELECT * FROM ciudad order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

}