using System.ComponentModel.DataAnnotations;

namespace Entidades.Models
{
    public class Grado
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(10)]
        public string Abreviatura { get; set; }
        [Required, MaxLength(50)]
        public string Descripcion { get; set; }
    }

}
