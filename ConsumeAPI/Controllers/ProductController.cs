using ConsumeAPI.Models;
using ConsumeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumeAPI.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAll();
            return View(result);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            var result = await _service.Add(product);
            return RedirectToAction("Index");
        }
    }
}
