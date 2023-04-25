using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Infra.Servicos
{
	public class ComandosSql
	{
		public static string PegarTodosPets = "SELECT * FROM Pet";
		public static string AdicionarNovoPet = "INSERT INTO Pet (Nome, Tipo, Sexo, Cor, DataDeNascimento, DataDeCadastro) " +
				   "VALUES (@Nome, @Tipo, @Sexo, @Cor, @DataDeNascimento, @DataDeCadastro)";
		

		public static string PegarPetPeloIdSql(int id)
		{
			return $"SELECT * FROM PET WHERE Id = {id}";
		}
		
		public static string EditarPet(int id)
		{
			return $"UPDATE Pet SET Nome=@Nome, Tipo=@Tipo, Sexo=@Sexo, Cor=@Cor, DataDeNascimento=@DataNascimento " +
					  $"WHERE ID={id}";
		}

		public static string RemoverPet(int id)
		{
			return $"DELETE FROM Pet WHERE Id = {id}";
		}
	}
}
