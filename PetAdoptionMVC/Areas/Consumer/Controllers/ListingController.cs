using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionMVC.Areas.Consumer.Controllers
{
    public class ListingController : Controller
    {
        [Area("Consumer")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
