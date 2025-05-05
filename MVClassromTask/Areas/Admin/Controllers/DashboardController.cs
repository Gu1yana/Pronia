using Microsoft.AspNetCore.Mvc;
using MVClassromTask.Repositories.Implement;

namespace MVClassromTask.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Creat()
        {
            SliderRepository repository = new ();
            var slider = repository.AddAsync(new() {Title="Gulyana", Description="Salam ALeykum", Price=67.88m, ImagePath= "1-1-310x220.jpg" });
            return Ok("Done");
        }
    }
}