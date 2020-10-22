using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Komis.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Komis.Controllers
{
    [Authorize]
    public class OpiniaController : Controller
    {
        private readonly IOpiniaRepository _opiniaRepository;

        public OpiniaController(IOpiniaRepository opiniaRepository)
        {
            _opiniaRepository = opiniaRepository;
        }

        [HttpGet] // nie jest wymagane jest umieszczenie. Dodane dla informacji jaki protokuł ta metoda obsługuje
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]// Wymagane !!! //POST is used to send data to a server to create/update a resource.
        public IActionResult Index(Opinia opinia)
        {
            if (ModelState.IsValid)
            {
                _opiniaRepository.DodajOpinie(opinia);
                return RedirectToAction("OpiniaWyslana");
            }

            return View(opinia);
            

        }
        public IActionResult OpiniaWyslana()
        {
            return View();

        }
    }
}