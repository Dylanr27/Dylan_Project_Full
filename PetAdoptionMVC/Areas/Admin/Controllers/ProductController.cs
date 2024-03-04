using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.DataAccess.Repository.IRepository;
using PetAdoption.Models;
using PetAdoption.Utility;

namespace PetAdoptionMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
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
                Product objProduct = _unitOfWork.product.Get(u => u.Id == id);

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

                    if (!string.IsNullOrEmpty(product.PhotoUrl)) 
                    {
                        var oldPhotoPath = Path.Combine(wwwRootPath, product.PhotoUrl.TrimStart('/'));

                        if (System.IO.File.Exists(oldPhotoPath)) 
                        {
                            System.IO.File.Delete(oldPhotoPath);
                        }
                    }

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

        #region API CALLS

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Product> objProductList = _unitOfWork.product.GetAll().ToList();
            return Json(new {  data = objProductList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id) 
        {
            Product? productToBeDeleted = _unitOfWork.product.Get(u =>u.Id == id);
            Listing? listingFromDb = _unitOfWork.listing.Get(u => u.ProductId == id);

            if (productToBeDeleted is null) 
            {
                return Json(new { success = false, message = "Error while deleting" }); 
            }

            if (productToBeDeleted.PhotoUrl is not null) 
            {
                var oldPhotoPath = Path.Combine(_webHostEnvironment.WebRootPath, productToBeDeleted.PhotoUrl.TrimStart('/'));
                
                if (System.IO.File.Exists(oldPhotoPath))
                {
                    System.IO.File.Delete(oldPhotoPath);
                }
            }

            _unitOfWork.product.Remove(productToBeDeleted);

            if(listingFromDb is not null) 
            {
                _unitOfWork.listing.Remove(listingFromDb);
            };

            _unitOfWork.Save();

            return Json(new { success = true, message = "Product removed successfully" });
        }

        #endregion

    }
}

