using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMais.Dominio.Notificacoes
{
	public class MensagensDeExcecoes
	{
		public static string MINIMO_2_LETRAS_MAXIMO_20 = "O nome tem que ter entre 2 e 20 letras";
		public static string O_NOME_NAO_PODE_TER_NUMEROS_E_ESPECIAIS = "O nome não pode conter números ou caracteres especiais";
		public static string DATA_DE_NASCIMENTO_NAO_PODE_SER_FUTURA = "Data de nascimento não pode ser futura";
		public static string IDADE_NAO_ULTRAPASSA_150_ANOS = "Idade do pet não pode ultrapassar 150 anos";

		public static string FALHA_PEGAR_PETS_DB = "Falha ao pegar lista de pets";
		public static string FALHA_AO_PEGAR_PET_PELO_ID = "Falha ao pegar pet pelo id";
		public static string FALHA_AO_CRIAR_NOVO_PET = "Falha ao criar novo pet";
		public static string FALHA_AO_EDITAR_PET = "Falha ao editar pet";
		public static string FALHA_AO_REMOVER_PET = "Falha ao remover pet";

		public static string CampoNaoPodeEstarVazioMensagem(string campo)
		{
			return $"O campo {campo} precisa ser selecionado";
		}
	}
}
