using EC.DataAccess.Repository.IRepository;
using EC.Models.ProductModels;
using EC.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EC.WEB.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> products = await unitOfWork.Products.GetAllAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Upsert(int? id)
        {
            IEnumerable<SelectListItem> categoryList = (await unitOfWork.Categories.GetAllAsync()).Select(it => new SelectListItem
            {
                Text = it.Name,
                Value = it.Id.ToString(),
            });

            //ViewBag.CategoryList = categoryList;
            //ViewData["CategoryList"] = categoryList;

            ProductVM productVM = new()
            {
                Product = new Product(),
                CategoryList = categoryList
            };

            if ((id ?? 0) > 0)
            {
                productVM.Product = await unitOfWork.Products.GetAsync(it => it.Id == id);
            }

            return View(productVM);
        }

        [HttpPost]
        public async Task<IActionResult> Upsert(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Products.AddAsync(productVM.Product);
                await unitOfWork.SaveAsync();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product? product = await unitOfWork.Products.GetAsync(it => it.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Product product)
        {
            await unitOfWork.Products.RemoveAsync(product);
            await unitOfWork.SaveAsync();
            TempData["success"] = "Product deleted successfully";

            return RedirectToAction("Index", "Product");
        }
    }
}
