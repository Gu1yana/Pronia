using Microsoft.AspNetCore.Mvc;
using MVClassromTask.Models;
using MVClassromTask.Repositories.Implement;

namespace MVClassromTask.Controllers
{
    public class BlogController : Controller
    {
        public class HomeModel
        {
            public List<Blog> Blogs { get; set; }
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            BlogRepository repository = new();
            var blogs = await repository.GetAllAsync();
            return View(blogs);
        }
    }
}
