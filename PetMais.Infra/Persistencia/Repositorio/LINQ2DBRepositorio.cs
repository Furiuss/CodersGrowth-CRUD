using LinqToDB;
using LinqToDB.Data;
using PetMais.Dominio.Notificacoes;
using PetMais.Dominio.Notifications;
using PetMais.Infra.Servicos;
using PetMais.Repository.Interfaces;
using System.Configuration;
using LinqToDB.DataProvider.SqlServer;
using System.Data.SqlClient;

namespace PetMais.Infra.Persistencia.Repositorio
{
	public class LINQ2DBRepositorio : IRepository
	{
		public LINQ2DBRepositorio() { }

		private DataConnection conexao;

		public ITable<Pet> _pet;

		public void AdicionarPet(Pet pet)
		{
			using var conexaoLinq2db = CriarConexao();

			try
			{
				pet.DataDeCadastro = DateTime.Now;
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
				return conexaoLinq2db.GetTable<Pet>().ToList();
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
				var pet = conexaoLinq2db.GetTable<Pet>().FirstOrDefault(p => p.Id == id);
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

		private DataConnection CriarConexao()
		{
			string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;			
			conexao = SqlServerTools.CreateDataConnection(connectionString);
			return conexao;
		}
	} 
}
