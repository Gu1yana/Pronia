using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVClassromTask.Contexts;
using MVClassromTask.Models;

namespace MVClassromTask.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ServiceController : Controller
	{
		public async Task<IActionResult> Index()
		{
			using var context = new ProniaDbContext();
			var service = await context.Services.ToListAsync();
			return View(service);
		}
		public IActionResult Create()
		{
			return View();
		}
		public async Task<IActionResult> Create(Service service)
		{
			if (!ModelState.IsValid)
				return View(service);
			using var context = new ProniaDbContext();
			await context.Services.AddAsync(service);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}
		public async Task<IActionResult> Delete(int? id)
		{
			if (id is null || id < 1)
				return BadRequest();
			using var context = new ProniaDbContext();
			var service = await context.Services.FirstOrDefaultAsync(x => x.Id == id);

			if (service == null)
				return NotFound();

			context.Services.Remove(service);
			await context.SaveChangesAsync();

			return RedirectToAction(nameof(Index));
		}
		//public async Task<IActionResult> Update(Service service)
		//{
		//	if (!ModelState.IsValid)
		//		return View(service);
		//	using var context = new ProniaDbContext();
		//	var existcontext = await context.Services.FirstOrDefaultAsync(x => x.Id == service.Id);
		//	if (existcontext == null)
		//		return BadRequest();
		//	var isExist = await context.Services.AnyAsync(x => x.Name == service.Name && );
		//}
	}
}
