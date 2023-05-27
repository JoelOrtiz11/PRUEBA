using System.ComponentModel.DataAnnotations;

namespace prueba.Models
{
    public class empresa
    {
        [Key]

        public int empresaID { get; set; }

        public string nombre { get; set; }

        public string correo { get; set; }

        public string telefono { get; set; }

        public string descripcion { get; set; }
    }
}
