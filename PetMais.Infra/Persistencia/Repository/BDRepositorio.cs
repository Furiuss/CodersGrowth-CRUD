using Microsoft.Data.SqlClient;
using PetMais.Enums;
using PetMais.Infra.Services;
using PetMais.Repository.Interfaces;
using PetMais.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetMais.Dominio.Notifications;
using PetMais.Dominio.Notificacoes;

namespace PetMais.Repository
{
    public class BDRepositorio : IRepository
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
		private SqlConnection con;

		public List<Pet> PegarListaDePets()
		{
			CriarConexao();

			List<Pet> pets = new List<Pet>();

			var sql = "SELECT * FROM Pet";

			SqlCommand cmd = new SqlCommand(sql, con);

			try
			{
				SqlDataReader reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Pet pet = new Pet()
					{
						Id = (int)reader.GetInt64(0),
						Nome = reader.GetString(1),
						Tipo = (TipoPet)Enum.Parse(typeof(TipoPet), reader.GetString(2)),
						Cor = (CorPet)Enum.Parse(typeof(CorPet), reader.GetString(3)),
						Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), reader.GetString(4)),
						DataDeNascimento = reader.GetDateTime(5),
						DataDeCadastro = reader.GetDateTime(6)
					};
					pets.Add(pet);
				}

				return pets;
			}
			catch (MensagensDeErros ex)
			{
				throw new MensagensDeErros(MensagensDeExcecoes.FALHA_PEGAR_PETS_DB);
			}
			finally
			{
				con.Close();
			}
		}

		public Pet PegarPetPeloId(int id)
		{
			CriarConexao();

			var sql = $"SELECT * FROM PET WHERE Id = {id}";

			SqlCommand cmd = new SqlCommand(sql, con);

			try
			{
				SqlDataReader reader = cmd.ExecuteReader();

				if (reader.Read())
				{
					Pet pet = new Pet()
					{
						Id = (int)reader.GetInt64(0),
						Nome = reader.GetString(1),
						Tipo = (TipoPet)Enum.Parse(typeof(TipoPet), reader.GetString(2)),
						Cor = (CorPet)Enum.Parse(typeof(CorPet), reader.GetString(3)),
						Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), reader.GetString(4)),
						DataDeNascimento = reader.GetDateTime(5),
						DataDeCadastro = reader.GetDateTime(6)
					};

					return pet;
				}
				else
				{
					return null;
				}

			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_PEGAR_PET_PELO_ID);
			}
			finally
			{
				con.Close();
			}
		}

		public void AdicionarPet(Pet pet)
		{
			var con = CriarConexao();


			var sql = "INSERT INTO Pet (Nome, Tipo, Sexo, Cor, DataDeNascimento, DataDeCadastro) " +
				   "VALUES (@Nome, @Tipo, @Sexo, @Cor, @DataDeNascimento, @DataDeCadastro)";

			SqlCommand cmd = new SqlCommand(sql, con);


			cmd.Parameters.AddWithValue("@Nome", pet.Nome);
			cmd.Parameters.AddWithValue("@Tipo", pet.Tipo.ToString());
			cmd.Parameters.AddWithValue("@Sexo", pet.Sexo.ToString());
			cmd.Parameters.AddWithValue("@Cor", pet.Cor.ToString());
			cmd.Parameters.AddWithValue("@DataDeNascimento", pet.DataDeNascimento);
			cmd.Parameters.AddWithValue("@DataDeCadastro", DateTime.Now);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_CRIAR_NOVO_PET);
			}
			finally
			{
				con.Close();
			}
		}

		public void EditarPet(Pet pet)
		{
			var con = CriarConexao();

			var sql = "UPDATE Pet SET Nome=@Nome, Tipo=@Tipo, Sexo=@Sexo, Cor=@Cor, DataDeNascimento=@DataNascimento " +
					  $"WHERE ID={pet.Id}";

			SqlCommand cmd = new SqlCommand(sql, con);

			cmd.Parameters.AddWithValue("@Nome", pet.Nome);
			cmd.Parameters.AddWithValue("@Tipo", pet.Tipo.ToString());
			cmd.Parameters.AddWithValue("@Sexo", pet.Sexo.ToString());
			cmd.Parameters.AddWithValue("@Cor", pet.Cor.ToString());
			cmd.Parameters.AddWithValue("@DataNascimento", pet.DataDeNascimento);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_EDITAR_PET);
			}
			finally
			{
				con.Close();
			}
		}

		public void RemoverPet(int id)
		{
			var con = CriarConexao();
			Pet pet = PegarPetPeloId(id);

			var sql = $"DELETE FROM Pet WHERE Id = {pet.Id}";

			SqlCommand cmd = new SqlCommand(sql, con);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (MensagensDeErros ex)
			{
				throw new Exception(MensagensDeExcecoes.FALHA_AO_REMOVER_PET);
			}
			finally
			{
				con.Close();
			}
		}

		private SqlConnection CriarConexao()
		{
			con = new SqlConnection(connectionString);
			con.Open();
			return con;
		}
	}
}
