using Microsoft.AspNetCore.Mvc;
using MovieApi.Persistence;

namespace MovieApi.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly MovieDbContext _context;

        public AuthController(MovieDbContext context)
        {
            _context = context;
        }
    }
}