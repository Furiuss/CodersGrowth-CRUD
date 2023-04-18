using PetMais.Enums;
using PetMais.Services;
using System.Drawing;
using System.Windows.Forms;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		private List<Pet> Pets = new List<Pet>();

		public TelaDeVisualizacao()
		{
			InitializeComponent();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(Pets);

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
				Pet petParaEditar = PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(Pets, petParaEditar);

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
			dgvListaDePets.DataSource = Pets;
		}

		void AtualizarDados()
		{
			dgvListaDePets.Update();
			dgvListaDePets.Refresh();
		}

		public Pet PegarPetPeloId(int id)
		{
			Pet pet = Pets.FirstOrDefault(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
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