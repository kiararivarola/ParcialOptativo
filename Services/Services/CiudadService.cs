using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class CiudadService
    {

        private CiudadRepository repositoryCiudad;

        public CiudadService(string connectionString)
        {
            this.repositoryCiudad = new CiudadRepository(connectionString);
        }

        public string insertarCiudad(CiudadModel ciudad)
        {
            return validarDatosCiudad(ciudad) ? repositoryCiudad.insertarCiudad(ciudad) : throw new Exception("Error en la validacion");
        }

        public string modificarCiudad(CiudadModel ciudad, int id)
        {
            if (repositoryCiudad.consultarCiudad(id) != null)
                return validarDatosCiudad(ciudad) ?
                    repositoryCiudad.modificarCiudad(ciudad, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta persona";
        }

        public string eliminarCiudad(int id)
        {
            return repositoryCiudad.eliminarCiudad(id);
        }

        public CiudadModel consultarCiudad(int id)
        {
            return repositoryCiudad.consultarCiudad(id);
        }

        public IEnumerable<CiudadModel> listarCiudad()
        {
            return repositoryCiudad.listarCiudad();
        }

        private bool validarDatosCiudad(CiudadModel ciudad)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }
    }
}
