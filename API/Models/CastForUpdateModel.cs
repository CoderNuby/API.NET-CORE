using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class CastForUpdateModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El caracter es requerido")]
        public string Character { get; set; }
    }
}
