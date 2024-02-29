using Microsoft.AspNetCore.Mvc;
using PetAdoption.Models;
using PetAdoption.DataAccess.Data;
using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.DataAccess.Repository;

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
            List<int?> existingProductIds = _unitOfWork.listing.GetAll().Select(l => l.ProductId).ToList();

            List<Product> allProducts = _unitOfWork.product.GetAll().ToList();

            List<Product> missingProducts = allProducts.Where(p => !existingProductIds.Contains(p.Id)).ToList();

            foreach (Product product in missingProducts)
            {
                Listing newListing = new Listing
                {
                    ProductId = product.Id,
                    Price = 14.85m
                };

                _unitOfWork.listing.Add(newListing);
            }

            _unitOfWork.Save();

            List<Listing> objProductListings = 
                _unitOfWork.listing.GetAll(includeProperties: "Product")
                .Where(listing => listing.Product is not null).ToList();

            return View(objProductListings);
        }

        public IActionResult AnimalListings() 
        {
            List<int?> existingAnimalIds = _unitOfWork.listing.GetAll().Select(l => l.AnimalId).ToList();

            List<Animal> allAnimals = _unitOfWork.animal.GetAll().ToList();

            List<Animal> missingAnimals = allAnimals.Where(a => !existingAnimalIds.Contains(a.Id)).ToList();

            foreach (Animal animal in missingAnimals) 
            {
                Listing newListing = new Listing
                {
                    AnimalId = animal.Id,
                    Price = 100.00m
                };


                _unitOfWork.listing.Add(newListing);
            }

            _unitOfWork.Save();

            List<Listing> objAnimalListings = 
                _unitOfWork.listing.GetAll(includeProperties: "Animal")
                .Where(listing => listing.Animal is not null).ToList();

            return View(objAnimalListings);
        }

        #region API CALLS

        [HttpGet]
        public IActionResult GetAllProductListings()
        {
            List<Listing> objProductListings =
                _unitOfWork.listing.GetAll(includeProperties: "Product")
                .Where(listing => listing.Product is not null).ToList();

            return Json(new { data = objProductListings });
        }
        
        [HttpGet]
        public IActionResult GetAllAnimalListings()
        {
            List<Listing> objAnimalListings =
                _unitOfWork.listing.GetAll(includeProperties: "Animal")
                .Where(listing => listing.Animal is not null).ToList();

            return Json(new { data = objAnimalListings });
        }

        #endregion
    }
}


