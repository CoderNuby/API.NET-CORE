
using System.Collections.Generic;

namespace API.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int NumeroActores { get; set; }
        public ICollection<CastModel> Casts { get; set; } = new List<CastModel>();
    }
}
