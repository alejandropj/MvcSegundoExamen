using Microsoft.AspNetCore.Mvc;
using MvcSegundoExamen.Models;
using MvcSegundoExamen.Services;

namespace MvcSegundoExamen.Controllers
{
    public class EventosController : Controller
    {
        private ServiceApiEventos service;
        public EventosController(ServiceApiEventos service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            ViewData["CATEGORIAS"] = categorias;
            List<Evento> eventos = await this.service.GetEventosAsync();
            return View(eventos);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int categoria)
        {
            List<CategoriaEvento> categorias = await this.service.GetCategoriasAsync();
            ViewData["EVENTOS"] = categorias;
            List<Evento> eventos = await this.service.FindEventosByCatAsync(categoria);
            return View(eventos);
        }
        
    }
}
