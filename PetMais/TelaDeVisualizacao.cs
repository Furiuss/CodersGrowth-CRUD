using PetMais.Enums;
using PetMais.Services;
using System.Drawing;
using System.Windows.Forms;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		private List<Pet> Pets;

		public TelaDeVisualizacao()
		{
			InitializeComponent();
			Pets = ListaDePets.GetInstancia();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro();

			if (telaDeCadastro.ShowDialog() == DialogResult.OK)
			{
				PopularDados();
			}
		}

		private void AoClicarNoBotaoEditar(object sender, EventArgs e)
		{
			int linhasSelecionadas = dgvListaDePets.SelectedRows.Count;

			try
			{
				VerificarLinhasSelecionada(linhasSelecionadas);
				int id = PegarIdDaLinhaSelecionada();
				Pet petParaEditar = ListaDePets.PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(petParaEditar);

				if (telaDeCadastro.ShowDialog() == DialogResult.OK)
				{
					PopularDados();
				}
			}
			catch (MensagensDeErros ex)
			{
				MessageBox.Show(ex.Message);
			}
		}


		private void AoClicarNoBotaoRemover(object sender, EventArgs e)
		{
			int linhasSelecionadas = dgvListaDePets.SelectedRows.Count;

			try
			{
				VerificarLinhasSelecionada(linhasSelecionadas);
				int indiceDaLinha = dgvListaDePets.CurrentRow.Index;
				int id = PegarIdDaLinhaSelecionada();
				Pet petParaRemover = ListaDePets.PegarPetPeloId(id);
				RemoverPet(petParaRemover);
				PopularDados();
			}
			catch (MensagensDeErros ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		int PegarIdDaLinhaSelecionada()
		{
			return int.Parse(dgvListaDePets.SelectedRows[0].Cells[0].Value.ToString());
		}

		void PopularDados()
		{
			dgvListaDePets.DataSource = null;
			dgvListaDePets.DataSource = ListaDePets.PegarListaDePets();
		}

		void RemoverPet(Pet pet)
		{
			ListaDePets.RemoverPet(pet);
		}

		void VerificarLinhasSelecionada(int linhaSelecionada)
		{
			if (linhaSelecionada > 1)
			{
				throw new MensagensDeErros("Selecione apenas uma linha para efetuar a edi��o");
			}

			if (linhaSelecionada < 1)
			{
				throw new MensagensDeErros("Selecione pelo menos uma linha para efetuar a edi��o");
			}
		}		
	}
}