using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersManegementSystem.Data;
using UsersManegementSystem.Models;

namespace UsersManegementSystem.Controllers
{
    public class InicioController : Controller
    {
        //private readonly ILogger<InicioController> _logger;
        private readonly ApplicationDbContext _context;
        public InicioController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost,ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(User user)
        {
            if (!ModelState.IsValid) {
                return View(user);

            }
            try
            {
                _context.User.Add(user);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Npgsql.PostgresException sqlEx && sqlEx.SqlState == "23505")
                {
                    ModelState.AddModelError("Email", "El correo electrónico ya está registrado.");
                }
                else
                {
                    ModelState.AddModelError("", "Ocurrió un error al registrar el usuario.");
                }
                return View(user);
            }
            
        }


        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            _context.User.ToList().ForEach(item => Console.WriteLine(item));
            return View(await _context.User.ToListAsync());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
