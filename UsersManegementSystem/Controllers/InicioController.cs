using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsersManegementSystem.Data;
using UsersManegementSystem.Data.Repository.IRepository;
using UsersManegementSystem.Models;

namespace UsersManegementSystem.Controllers
{
    public class InicioController : Controller
    {
        //private readonly ILogger<InicioController> _logger;
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public InicioController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
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

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _contenedorTrabajo.User.Add(user);
                _contenedorTrabajo.Save();

                return Json(new { status = "success", message = "Usuario registrado correctamente",data =  _contenedorTrabajo.User.GetAll() });
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is Npgsql.PostgresException sqlEx && sqlEx.SqlState == "23505")
                {
                    return Json(new { status = "error", message = "El correo electrónico ya está registrado." });
                }

                return Json(new { status = "error", message = $"Ocurrió un error al registrar el usuario. {ex}" });
            }

        }


        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Manage()
        {
            
            return View( _contenedorTrabajo.User.GetAll());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
