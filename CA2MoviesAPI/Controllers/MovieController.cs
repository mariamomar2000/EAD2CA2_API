using CA2MoviesAPI.Data;
using CA2MoviesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CA2MoviesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : Controller
    {
        /*
         * GET /api/movie/ get all movies
         * GET /api/movie/Name get matching movie
         * GET /api/movie/Genre get matching movies with genre
         */
        private readonly MovieContext _context;
        public MovieController(MovieContext context)
        {
            _context = context;
        }

        // GET api/Movie/
        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<Movie>> GetMovies()
        {
            return Ok(await _context.Movies.OrderBy(i => i.Name).ToListAsync());
        }

        // GET api/Movie/movieId/
        [HttpGet("id/{id}/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger doc/UI
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> GetMovieById(int id)
        {
            Movie movie = _context.Movies.FirstOrDefault(i => i.ID == id);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        // GET api/Movie/genre/
        [HttpGet("genre/{genre}/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger doc/UI
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Movie> GetMoviesByGenre(string genre)
        {
            IEnumerable<Movie> movies = _context.Movies.Where(i => i.Genre == genre);
            if (movies == null)
            {
                return NotFound();
            }
            return Ok(movies);
        }

        // GET api/Movie/movieId/comments/
        [HttpGet("id/{id}/comments/", Name = "GetComments")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger doc/UI
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MovieComment> GetMovieComments(int id)
        {
            var movieComments = _context.MovieComments.Where(i => i.MovieID == id).OrderByDescending(i => i.Created);
            if (movieComments == null)
            {
                return NotFound();
            }
            return Ok(movieComments);
        }

        // GET api/Movie/movieId/comments/id
        [HttpGet("id/{id}/comments/{cid}/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)] // for swagger doc/UI
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MovieComment> GetMovieCommentByID(int id, int cid)
        {
            MovieComment movieComment = _context.MovieComments.FirstOrDefault(i => i.MovieID == id && i.ID == cid);
            if (movieComment == null)
            {
                return NotFound();
            }
            return Ok(movieComment);
        }

        // POST api/Movie/movieId/comments/
        [HttpPost("id/{id}/comments/")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status201Created)] // for swagger doc/UI
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<MovieComment> PostComment(int id, [FromBody] MovieComment comment)
        {
            if (comment == null) return BadRequest("Request body is empty");

            var movie = _context.Movies.FirstOrDefault(i => i.ID == id);
            if (movie == null) {
                return BadRequest("Movie does not exist");
            } else
            {
                MovieComment newComment = new MovieComment { Comment = comment.Comment, Created = System.DateTime.Now, MovieID = id };
                movie.Count++;
                movie.Rating += comment.Movie.Rating;
                _context.MovieComments.Add(newComment);
                _context.SaveChanges();
                return CreatedAtRoute("GetComments", new { id = comment.MovieID }, comment);
            }
        }
    }
}
