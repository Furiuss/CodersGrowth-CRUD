using Microsoft.AspNetCore.Mvc;
using PetMais.Services;

namespace PetMais.Web.Controllers
{
	public class PetController : ControllerBase
	{
		[HttpGet]
		public IActionResult PegarTodosPets()
		{
			return View();
		}

		[HttpGet("{id}")]
		public IActionResult PegarPetPeloId(int id)
		{
			return View();
		}

		[HttpPost]
		public IActionResult AdicionarNovoPet(Pet novoPet)
		{
			if (novoPet == null) { return BadRequest(); }
			ValidarForm.ValidacaoDosCampos(novoPet);

			return View();
		}

		[HttpPut("{id}")]
		public IActionResult EditarPet(int id, Pet pet)
		{
			return View();
		}

		[HttpDelete("{id}")]
		public IActionResult RemoverPet(int id)
		{
			return View();
		}
	}
}
