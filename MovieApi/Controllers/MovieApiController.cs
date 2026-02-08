using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.Persistence;
using MovieApi.Dtos;

namespace MovieApi.Controllers;

[ApiController]
[Route("api/movies")]
public class MovieApiController : ControllerBase
{
   private readonly MovieDbContext _context;

   public MovieApiController(MovieDbContext context)
   {
      _context = context;
   }

   [HttpGet]
   public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
   {
      return await _context.Movies.ToListAsync();
   }

   [HttpGet("{id}")]
   public async Task<ActionResult<Movie>> GetMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if(movie == null)
        {
            return NotFound($"Movie with id {id} not found.");
        }
        return movie;
    }
   [HttpPost]
   public async Task<ActionResult<Movie>> CreateMovie(CreateMovie createMovie)
    {
        var newMovie = new Movie
        {
            Title = createMovie.Title,
            Director = createMovie.Director,
            DurationMinutes = createMovie.DurationMinutes,
            Rating = createMovie.Rating
        };
        
        _context.Movies.Add(newMovie);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetMovie), new { id = newMovie.Id }, newMovie);

    }
   //[HttpPut("{id}")]
   //[HttpDelete("{id}")]

}
