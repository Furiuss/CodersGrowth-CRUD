using PetMais.Enums;
using PetMais.Repository;
using PetMais.Repository.Interfaces;
using PetMais.Services;
using System.Drawing;
using System.Windows.Forms;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		IRepository Repositorio;

		public TelaDeVisualizacao(IRepository repositorio)
		{
			InitializeComponent();
			Repositorio = repositorio;
			PopularDados();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(Repositorio);

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
				Pet petParaEditar = Repositorio.PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(Repositorio, petParaEditar);

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
				Pet petParaRemover = Repositorio.PegarPetPeloId(id);
				RemoverPet(petParaRemover.Id);
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
			dgvListaDePets.DataSource = Repositorio.PegarListaDePets();
		}

		void RemoverPet(int id)
		{
			Repositorio.RemoverPet(id);
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