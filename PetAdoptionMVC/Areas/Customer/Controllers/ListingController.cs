using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;

namespace PetAdoptionMVC.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ListingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ListingController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }
        
        public IActionResult ProductListings()
        {
            List<Product> objProductList = _unitOfWork.product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult AnimalListings() 
        {
            List<Animal> objAnimalList = _unitOfWork.animal.GetAll().ToList();
            return View(objAnimalList);
        }
    }
}
