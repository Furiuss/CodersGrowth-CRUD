using Microsoft.AspNetCore.Mvc;
using PetMais.Repository;
using PetMais.Repository.Interfaces;
using PetMais.Services;

namespace PetMais.Web.Controllers
{
	[Route("api/pets")]
	[ApiController]
	public class PetController : ControllerBase
	{

		private readonly IRepository _repository;

		public PetController (IRepository repository)
		{
			_repository = repository;
		}

		[HttpGet]
		public IActionResult PegarListaDePets()
		{
			var pets = _repository.PegarListaDePets();
			return Ok(pets);
		}

		[HttpGet("{id}")]
		public IActionResult PegarPetPeloId(int id)
		{
			var pet = _repository.PegarPetPeloId(id);
			if (pet == null)  { return NotFound(); }
			return Ok(pet);
		}

		[HttpPost]
		public IActionResult AdicionarPet([FromBody] Pet novoPet)
		{
			if (novoPet == null) { return BadRequest(); }
			ValidarForm.ValidacaoDosCampos(novoPet);
			_repository.AdicionarPet(novoPet);
			return CreatedAtAction(nameof(PegarPetPeloId), new { id = novoPet.Id }, novoPet);
		}

		[HttpPut("{id}")]
		public IActionResult EditarPet(int id, [FromBody] Pet petEditado)
		{
			var petAtual = _repository.PegarPetPeloId(id);
			if (petAtual == null) { return NotFound(); }
			if (petEditado == null) { return BadRequest(); }			
			petEditado.Id = petAtual.Id;
			petEditado.DataDeCadastro = petAtual.DataDeCadastro;
			ValidarForm.ValidacaoDosCampos(petEditado);
			_repository.EditarPet(petEditado);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public IActionResult RemoverPet(int id)
		{
			var petParaRemover = _repository.PegarPetPeloId(id);
			if (petParaRemover == null) { return NotFound(); }
			_repository.RemoverPet(petParaRemover.Id);
			return NoContent();
		}
	}
}
