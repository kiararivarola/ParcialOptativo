using Infraestructure.Models;
using Infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OperacionesCuentaService
    {
        private OperacionesCuentaService repositoryOperacionesCuentaService;

        public OperacionesCuentaService(string connectionString)
        {
            this.repositoryOperacionesCuentaService = new OperacionesCuentaService(connectionString);
        }

        public string depositar(CuentaModel cuenta)
        {
            return validarDatos(cuenta) ? repositoryOperacionesCuentaService.depositar(cuenta) : throw new Exception("Error en la validación");
        }
        
        public string transferir(CuentaModel cuenta)
        {
            return validarDatos(cuenta) ? repositoryOperacionesCuentaService.transferir(cuenta) : throw new Exception("Error en la validación");
        }
        
        public string bloquear(CuentaModel cuenta)
        {
            return validarDatos(cuenta) ? repositoryOperacionesCuentaService.bloquear(cuenta) : throw new Exception("Error en la validación");
        }
        
        public string imprimirExtracto(CuentaModel cuenta)
        {
            return validarDatos(cuenta) ? repositoryOperacionesCuentaService.imprimirExtracto(cuenta) : throw new Exception("Error en la validación");
        }
        
        private bool validarDatos(CuentaModel cuenta)
        {
            if (cuenta.numeroCuenta == null || cuenta.saldo < 0)
            {
                return true;
            }
            return false;
        }

    }
}
