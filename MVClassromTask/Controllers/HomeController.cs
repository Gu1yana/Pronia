using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVClassromTask.Contexts;
using MVClassromTask.Repositories.Implement;
using MVClassromTask.ViewModelsGroup;

namespace MVClassromTask.Controllers
{
    public class HomeController(ProniaDbContext _context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var services=await _context.Services.ToListAsync();
            List<SliderGetVM> vm1 = [];
            List<ServiceGetVM> vm2= [];

            foreach (var slider in sliders)
            {
                SliderGetVM slidervm = new()
                {
                    Title = slider.Title,
                    Description = slider.Description,
                    ImagePath = slider.ImagePath,
                    Price = slider.Price,
                };
                vm1.Add(slidervm);
            }
            foreach (var service in services)
            {
                ServiceGetVM servicevm = new()
                {
                    Title = service.Title,
                    Description = service.Description,
                    ImagePath = service.ImagePath,
                };
                vm2.Add(servicevm);
            }
            HomeVM homeVm = new()
            {
                Sliders = vm1,
                Services = vm2
            };
            return View(homeVm);
        }
    }
}