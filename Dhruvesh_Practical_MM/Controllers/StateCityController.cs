using Dhruvesh_Practical_MM.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO.Pipes;

namespace Dhruvesh_Practical_MM.Controllers
{
    public class StateCityController : Controller
    {
        private readonly IStateCityRepo _stateCityRepo;

        public StateCityController(IStateCityRepo stateCityRepo)
        {
            _stateCityRepo = stateCityRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetAllState()
        {
            var getstate = _stateCityRepo.GetAllState();
            return Json(getstate);
        }

        public IActionResult GetCityByState(int id)
        {
            var getcity = _stateCityRepo.GetCityByState(id);
            return Json(getcity);
        }

    }
}
