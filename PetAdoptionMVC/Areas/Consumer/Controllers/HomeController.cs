using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using System.Diagnostics;

namespace PetAdoptionMVC.Areas.Consumer.Controllers
{
    [Area("Consumer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
