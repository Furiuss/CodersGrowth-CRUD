using LinqToDB;
using PetMais.Dominio.Notificacoes;
using PetMais.Dominio.Notifications;
using PetMais.Infra.Modelos;
using PetMais.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Persistencia.Repositorio
{
	public class LINQ2DBRepositorio : LinqToDB.Data.DataConnection, IRepository
	{
		public LINQ2DBRepositorio() : base("ConnectionString") { }

		public ITable<PetModelo> _pet => this.GetTable<PetModelo>();

		public void AdicionarPet(Pet pet)
		{
			using var conexaoLinq2db = CriarConexao();

			try
			{
				conexaoLinq2db.Insert(pet);
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_CRIAR_NOVO_PET);
			}
		}

		public void EditarPet(Pet petEditado)
		{
			using var conexaoLinq2db = CriarConexao();

			try
			{
				conexaoLinq2db.Update(petEditado);
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_EDITAR_PET);
			}
		}

		public List<Pet> PegarListaDePets()
		{
			using var conexaoLinq2db = CriarConexao();
			try
			{
				var pets = from p in conexaoLinq2db._pet select p;
				return (List<Pet>)pets;
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_PEGAR_PETS_DB);
			}
		}

		public Pet PegarPetPeloId(int id)
		{
			using var conexaoLinq2db = CriarConexao();
			try
			{
				var pet = from p in conexaoLinq2db._pet where p.Id == id select p;
				return (Pet)pet;
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_PEGAR_PET_PELO_ID);
			}
		}

		public void RemoverPet(int id)
		{
			using var conexaoLinq2db = CriarConexao();
			try
			{
				var pet = PegarPetPeloId(id);
				conexaoLinq2db.Delete(pet);
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_PEGAR_PET_PELO_ID);
			}
		}

		private LINQ2DBRepositorio CriarConexao()
		{
			return new LINQ2DBRepositorio();
		}
	}
}
