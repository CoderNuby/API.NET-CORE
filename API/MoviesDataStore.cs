using API.Models;
using System.Collections.Generic;

namespace API
{
    public class MoviesDataStore
    {
        public static MoviesDataStore Instance { get; set; } = new MoviesDataStore();
        public List<MovieModel> movies;
        public MoviesDataStore()
        {
            movies = new List<MovieModel>()
            {
                new MovieModel()
                {
                    Id = 1,
                    Nombre = "Shruek",
                    Descripcion = "Pelicula de shruek",
                    Casts = new List<CastModel>()
                    {
                        new CastModel{ Id = 1, Nombre = "Mike Myers", Descripcion = "Hace la voz de Shrek"},
                        new CastModel{ Id = 2, Nombre = "Eddie Murphy", Descripcion = "Hace la voz de burro"},
                        new CastModel{ Id = 3, Nombre = "Cameron Diaz", Descripcion = "Hece la voz de la princesa Fiona"},
                    }
                },
                new MovieModel()
                {
                    Id = 2,
                    Nombre = "The Returned Missionary",
                    Descripcion = "pelicula de La Iglesia de Jesucristo de los santos de los ultimos dias",
                    Casts = new List<CastModel>()
                    {
                        new CastModel{ Id = 1, Nombre = "Kirby Heyborne", Descripcion = "Interpreta a Jared Phelps"},
                        new CastModel{ Id = 2, Nombre = "Britani Bateman", Descripcion = "Interpreta a Kelly Powers"},
                        new CastModel{ Id = 3, Nombre = "Will Swenson", Descripcion = "Kori Swenson"},
                    }
                }
            };
        }
    }
}
