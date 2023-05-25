namespace ParcialOptativo.Model
{
    public class CuentaModel
    {
        public int Id { get; set; }

        public string nombreCuenta { get; set; }

        public string numeroCuenta { get; set; }

        public string saldo { get; set; }

        public string limiteSaldo { get; set; }

        public string limiteTransferencia { get; set; }

        public string estadocuenta { get; set; }

        public int idPersona { get; set; }
    }
}
