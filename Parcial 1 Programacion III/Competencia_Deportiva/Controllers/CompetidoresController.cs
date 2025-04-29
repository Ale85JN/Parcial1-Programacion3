using Competencia_Deportiva.Datos;
using Competencia_Deportiva.Models;
using Microsoft.AspNetCore.Mvc;

namespace Competencia_Deportiva.Controllers
{
    public class CompetidoresController : Controller
    {
        CompetidoresDatos _CD = new CompetidoresDatos();
        public IActionResult Index()
        {
            return View(_CD.listarCompetidores());
        }

        public IActionResult Create()
        {
            ViewBag.Disciplinas = _CD.ListarDisciplina();
            return View();
        }
        [HttpPost]

        public IActionResult Create(Competidores competidores)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Disciplinas = _CD.ListarDisciplina();
                    return View();
                }
                ViewBag.Error = _CD.Crear(competidores);
                if (ViewBag.Error != "")
                {
                    ViewBag.Disciplinas = _CD.ListarDisciplina();
                    return View();
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.Disciplinas = _CD.ListarDisciplina();
                return View();
            }
        }
    }    
}
