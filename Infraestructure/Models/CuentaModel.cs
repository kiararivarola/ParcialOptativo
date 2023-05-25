using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    public class CuentaModel
    {
        public int Id { get; set; }

        public string nombreCuenta { get; set; }

        public string numeroCuenta { get; set; }

        public double saldo { get; set; }

        public string limiteSaldo { get; set; }

        public string limiteTransferencia { get; set; }

        public string estadocuenta { get; set; }

        public int idPersona { get; set; }
    }
}
