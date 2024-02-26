using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    public class Listing : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
