using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieApi.Models;
using MovieApi.Persistence;

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
   //[HttpGet("{id}")]
   //[HttpPost]
   //[HttpPut("{id}")]
   //[HttpDelete("{id}")]

}
