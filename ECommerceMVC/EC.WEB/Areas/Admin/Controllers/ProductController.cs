using EC.DataAccess.Repository.IRepository;
using EC.Models.ProductModels;
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
        public async Task<IActionResult> Create()
        {
            IEnumerable<SelectListItem> categoryList = (await unitOfWork.Categories.GetAllAsync()).Select(it => new SelectListItem
            {
                Text = it.Name,
                Value = it.Id.ToString(),
            });

            ViewData["CategoryList"] = categoryList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Products.AddAsync(product);
                await unitOfWork.SaveAsync();
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index", "Product");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? product = await unitOfWork.Products.GetAsync(it => it.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.Products.UpdateAsync(product);
                await unitOfWork.SaveAsync();
                TempData["success"] = "Product edited successfully";
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
