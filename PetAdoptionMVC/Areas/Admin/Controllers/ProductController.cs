using Microsoft.AspNetCore.Mvc;
using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.Models;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) 
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.product.GetAll().ToList();
            return View(objProductList);
        }

        public IActionResult Upsert(int? id) 
        {
            if (id == null || id == 0)
            {
                return View();
            }
            else 
            {
                Product objProduct = _unitOfWork.product.Get(u=> u.Id ==id);
                return View(objProduct);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Product product, IFormFile? file) 
        {
            if (ModelState.IsValid) 
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null) 
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"Images\Products");

                    using (var fileStream = new FileStream(
                        Path.Combine(productPath, fileName), 
                        FileMode.Create)) 
                    {
                        file.CopyTo(fileStream);
                    }

                    product.PhotoUrl = @"/Images/Products/" + fileName;
                }
                if (product.Id == 0)
                {
                    _unitOfWork.product.Add(product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product added successfully";
                }
                else

                {
                    _unitOfWork.product.Update(product);
                    _unitOfWork.Save();
                    TempData["success"] = "Product updated successfully";
                }

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
