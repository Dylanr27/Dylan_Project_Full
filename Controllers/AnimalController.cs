using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionMVC.Controllers
{
    public class AnimalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
