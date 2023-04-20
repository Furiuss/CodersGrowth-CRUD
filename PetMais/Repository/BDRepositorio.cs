using Microsoft.Data.SqlClient;
using PetMais.Enums;
using PetMais.Repository.Interfaces;
using PetMais.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Repository
{
	public class BDRepositorio : IRepository
	{
		private static string connectionString = ConfigurationManager.ConnectionStrings["PetMais"].ConnectionString;

		public List<Pet> PegarListaDePets()
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();

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
				throw new MensagensDeErros("Falha ao pegar lista de pets");
			}
			finally
			{
				con.Close();
			}
		}

		public Pet PegarPetPeloId(int id)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();

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
				throw new MensagensDeErros("Falha ao pegar lista de pets");
			}
			finally
			{
				con.Close();
			}
		}

		public void AdicionarPet(Pet pet)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();


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
				throw new MensagensDeErros("Falha ao cadastrar pet");
			}
			finally
			{
				con.Close();
			}
		}

		public void EditarPet(Pet petEditado)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();

			var sql = "UPDATE Pet SET Nome=@Nome, Tipo=@Tipo, Sexo=@Sexo, Cor=@Cor, DataDeNascimento=@DataNascimento " +
					  $"WHERE ID={petEditado.Id}";

			SqlCommand cmd = new SqlCommand(sql, con);

			cmd.Parameters.AddWithValue("@Nome", petEditado.Nome);
			cmd.Parameters.AddWithValue("@Tipo", petEditado.Tipo.ToString());
			cmd.Parameters.AddWithValue("@Sexo", petEditado.Sexo.ToString());
			cmd.Parameters.AddWithValue("@Cor", petEditado.Cor.ToString());
			cmd.Parameters.AddWithValue("@DataNascimento", petEditado.DataDeNascimento);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (MensagensDeErros ex)
			{
				throw new MensagensDeErros("Falha ao editar pet");
			}
			finally
			{
				con.Close();
			}
		}

		public void RemoverPet(Pet pet)
		{
			SqlConnection con = new SqlConnection(connectionString);
			con.Open();

			var sql = $"DELETE FROM Pet WHERE Id = {pet.Id}";

			SqlCommand cmd = new SqlCommand(sql, con);

			try
			{
				cmd.ExecuteNonQuery();
			}
			catch (MensagensDeErros ex)
			{
				throw new MensagensDeErros("Falha ao remover pet");
			}
			finally
			{
				con.Close();
			}
		}
	}
}
