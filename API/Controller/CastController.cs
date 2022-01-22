using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace API.Controller
{
    [Route("api/movies/{movieId}/[controller]")]
    [ApiController]
    public class CastController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCasts(int movieId)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie.Casts);
        }

        [HttpGet("{id}", Name = "GetCast")]
        public IActionResult GetCast(int movieId, int id)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);

            if (movie == null)
            {
                return NotFound("Pelicula no encotrada con el criterio proporcionado");
            }

            var cast = movie.Casts.FirstOrDefault(x => x.Id == id);

            if (cast == null)
            {
                return NotFound("Cast no encontrado con el criterio proporcionado");
            }

            return Ok(cast);
        }

        [HttpPost]
        public IActionResult CreateCast(int movieId, [FromBody] CastForCreationModel castModel)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return BadRequest("No se encontro ninguna pelicula con ese criterio proporcionado");
            }

            var maxCastId = MoviesDataStore.Instance.movies.SelectMany(x => x.Casts).Max(p => p.Id);

            var newCast = new CastModel()
            {
                Id = ++maxCastId,
                Nombre = castModel.Nombre,
                Character = castModel.Character,
            };

            movie.Casts.Add(newCast);

            return CreatedAtRoute(nameof(GetCast), new { movieId, id = newCast.Id }, castModel);
        }

        [HttpPut]
        public IActionResult UpdateCast(int movieId, [FromBody] CastForUpdateModel castModel)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return BadRequest("No se encontro ninguna pelicula con ese criterio proporcionado");
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == castModel.Id);

            if (castFromStore == null)
            {
                return NotFound("El recurso cast no fue encontrado");
            }

            castFromStore.Nombre = castModel.Nombre;
            castFromStore.Character = castModel.Character;

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartialUpdateCast(int movieId, int id, [FromBody] JsonPatchDocument<CastForUpdateModel> jsonPatch)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return BadRequest("No se encontro ninguna pelicula con ese criterio proporcionado");
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == id);

            if (castFromStore == null)
            {
                return NotFound("El recurso cast no fue encontrado");
            }

            var castToPatch = new CastForUpdateModel()
            {
                Nombre = castFromStore.Nombre,
                Character = castFromStore.Character
            };

            jsonPatch.ApplyTo(castToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest("Model state no es valido");
            }

            if (!TryValidateModel(castToPatch))
            {
                return BadRequest(ModelState);
            }

            castFromStore.Nombre = castToPatch.Nombre;
            castFromStore.Character= castToPatch.Character;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCast(int movieId, int id)
        {
            var movie = MoviesDataStore.Instance.movies.FirstOrDefault(x => x.Id == movieId);
            if (movie == null)
            {
                return BadRequest("No se encontro ninguna pelicula con ese criterio proporcionado");
            }

            var castFromStore = movie.Casts.FirstOrDefault(x => x.Id == id);

            if (castFromStore == null)
            {
                return NotFound("El recurso cast no fue encontrado");
            }

            movie.Casts.Remove(castFromStore);

            return NoContent();
        }
    }
}
