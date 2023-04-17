using PetMais.Enums;
using PetMais.Services;
using System.Windows.Forms;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		private ListaDePets ListaDePets = new ListaDePets();

		public TelaDeVisualizacao()
		{
			InitializeComponent();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(ListaDePets);

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
				DataGridViewRow row = dgvListaDePets.SelectedRows[0];
				int id = int.Parse(dgvListaDePets.SelectedRows[0].Cells["ID"].Value.ToString());
				Pet petParaEditar = ListaDePets.PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(ListaDePets, petParaEditar);

				if (telaDeCadastro.ShowDialog() == DialogResult.OK)
				{
					AtualizarDados();
				}
			}
			catch (MensagensDeErros ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		void PopularDados()
		{
			dgvListaDePets.DataSource = null;
			dgvListaDePets.DataSource = ListaDePets.MostrarPets();
		}

		void AtualizarDados()
		{
			dgvListaDePets.Update();
			dgvListaDePets.Refresh();
		}

		void VerificarLinhasSelecionada(int linhaSelecionada)
		{
			if (linhaSelecionada > 1)
			{
				throw new MensagensDeErros("Selecione apenas uma linha para efetuar a edição");
			}

			if (linhaSelecionada < 1)
			{
				throw new MensagensDeErros("Selecione pelo menos uma linha para efetuar a edição");
			}
		}
	}
}