using Microsoft.AspNetCore.Mvc;
using MVClassromTask.Repositories.Implement;

namespace MVClassromTask.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            SliderRepository repository = new();
            var sliders=await repository.GetAllAsync();
            return View(sliders);
        }
    }
}