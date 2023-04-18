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
				int id = PegarIdDaLinhaSelecionada();
				Pet petParaEditar = PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(Pets, petParaEditar);

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
				Pet petParaRemover = PegarPetPeloId(id);
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
			dgvListaDePets.DataSource = Pets;
		}

		void RemoverPet(Pet pet)
		{
			Pets.Remove(pet);
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
				throw new MensagensDeErros("Selecione apenas uma linha para efetuar a edi��o");
			}

			if (linhaSelecionada < 1)
			{
				throw new MensagensDeErros("Selecione pelo menos uma linha para efetuar a edi��o");
			}
		}		
	}
}