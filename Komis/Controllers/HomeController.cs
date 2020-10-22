using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Komis.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Komis.Controllers
{
    public class HomeController : Controller
    {

        private readonly ISamochodRepository _samochodRepository;

        public HomeController(ISamochodRepository samochodRepository)
        {
            _samochodRepository = samochodRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var samochody = _samochodRepository.PobierzWszystkieSamochody().OrderBy(s => s.Marka);

            var homeViewModel = new HomeViewModel()
            {
                Tytul = "Przegląd samochodów",
                Samochody = samochody.ToList() 
            };

            return View(homeViewModel);
        }
        public IActionResult Szczegoly(int id)
        {
            var samochod = _samochodRepository.PobierzSamochodOId(id);

            if (samochod == null)
                return NotFound();

            return View(samochod);
        }
    }
}
