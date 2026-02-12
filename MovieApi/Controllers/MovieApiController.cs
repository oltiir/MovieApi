using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.Persistence;
using MovieApi.Dtos;
using Microsoft.AspNetCore.Authorization;

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
   [Authorize]
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
   [HttpPut("{id}")]
   [Authorize]
   public async Task<IActionResult> UpdateMovie(int id, UpdateMovie updateMovie)
    {
        var dbMovie = await _context.Movies.FindAsync(id);
        if(dbMovie == null)
        {
            return NotFound($"Movie with id {id} doesnt exist.");
        }
        dbMovie.Title = updateMovie.Title;
        dbMovie.Director = updateMovie.Director;
        dbMovie.DurationMinutes = updateMovie.DurationMinutes;
        dbMovie.Rating = updateMovie.Rating;

        await _context.SaveChangesAsync();
        return NoContent();
    }
   [HttpDelete("{id}")]
   [Authorize]
   public async Task<IActionResult> DeleteMovie(int id)
    {
        var movie = await _context.Movies.FindAsync(id);
        if(movie == null)
        {
            return NotFound($"The movie with id {id} doesnt exist.");
        }

        _context.Movies.Remove(movie);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
