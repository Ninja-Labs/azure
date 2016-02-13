using AspnetApiAndDocumentDB.Data;
using AspnetApiAndDocumentDB.Models;
using Microsoft.AspNet.Mvc;
using System.Threading.Tasks;

namespace AspnetApiAndDocumentDB.Controllers
{
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {

        [HttpGet]
        public IActionResult GetAllMovies()
        {
            var movies = MovieRepository.GetAllMovies();
            if (movies == null)
                return HttpNotFound();

            return Ok(movies);
        }

        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetMovieById(string id)
        {
            var movie = MovieRepository.GetMovieById(id);
            if (movie == null)
                return HttpNotFound();

            return Ok(movie);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Movie entity)
        {
            var movie = await MovieRepository.CreateMovie(entity);
            return CreatedAtRoute("GetMovie", new { controller = "Movie", id = entity.Id }, entity);
        }
    }
}
