using EC.WEB.Data;
using EC.WEB.Models.Category;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EC.WEB.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            List<Category> categories = await dbContext.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "This DisplayOrder cannot exactly match the Name.");
            }
            if (ModelState.IsValid)
            {
                await dbContext.Categories.AddAsync(category);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Category? category = await dbContext.Categories.FirstOrDefaultAsync(it => it.Id == id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                dbContext.Categories.Update(category);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
    }
}
