using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetMovies()
        {
            return Ok(MoviesDataStore.Instance.movies);
        }

        [HttpGet("{id}")]
        public IActionResult GetMovie(int id)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }
    }
}
