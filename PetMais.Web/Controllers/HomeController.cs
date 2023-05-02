using Microsoft.AspNetCore.Mvc;

namespace PetMais.Web.Controllers
{
	[ApiController]
	[Route("")]
	public class HomeController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
			return PhysicalFile(filePath, "text/html");
		}
	}
}
