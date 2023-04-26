using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure.Models
{
    public class ClienteModel
    {

        public int id { get; set; }

        public String nombre { get; set; }

        public String apellido { get; set; }

        public String documentoNum { get; set; }

        public String telefono { get; set; }

        public String fechaNacimiento { get; set; }

        public String nacionalidad { get; set; }

        public String ciudad { get; set; }

        public int idCiudad { get; set; }

        public String email { get; set; }

    }
}
