using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ClienteService
    {
        private ClienteRepository repositoryCliente;

        public ClienteService(string connectionString)
        {
            this.repositoryCliente = new ClienteRepository(connectionString);
        }

        public string insertarCliente(ClienteModel cliente)
        {
            return validarDatosCliente(cliente) ? repositoryCliente.insertarCliente(cliente) : throw new Exception("Error en la validacion");
        }

        public string modificarCliente(ClienteModel cliente, int id)
        {
            if (repositoryCliente.consultarCliente(id) != null)
                return validarDatosCliente(cliente) ?
                    repositoryCliente.modificarCliente(cliente, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta persona";
        }

        public string eliminarCliente(int id)
        {
            return repositoryCliente.eliminarCliente(id);
        }

        public ClienteModel consultarCliente(int id)
        {
            return repositoryCliente.consultarCliente(id);
        }

        public IEnumerable<ClienteModel> listarCliente()
        {
            return repositoryCliente.listarCliente();
        }

        private bool validarDatosCliente(ClienteModel cliente)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }
    }

}
