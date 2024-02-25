using Microsoft.AspNetCore.Mvc;
using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.Models;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product) 
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.product.Add(product);
                _unitOfWork.Save();
                TempData["success"] = "Product added successfully";

                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors) 
            {
                TempData["error"] = error.ErrorMessage;
                break;
            }

            return View();
        }

        public IActionResult Edit(int? id) 
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Product product) 
        {
            if (ModelState.IsValid) 
            {
                _unitOfWork.product.Update(product);
                _unitOfWork.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }

            var errors = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var error in errors)
            {
                TempData["error"] = error.ErrorMessage;
                break;
            }

            return View();
        }

        public IActionResult Delete(int? id) 
        {
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            Product? productFromDb = _unitOfWork.product.Get(u => u.Id == id);

            if (productFromDb == null) 
            {
                return NotFound();
            }

            return View(productFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Delete(int id) 
        {
            Product? productFromDb = _unitOfWork.product.Get(u => u.Id == id);

            if (productFromDb == null) 
            {
                return NotFound();
            }

            _unitOfWork.product.Remove(productFromDb);
            _unitOfWork.Save();
            TempData["success"] = "Product removed successfully";
            return RedirectToAction("Index");
        }
    }
}
