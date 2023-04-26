using PetMais.Enums;
using PetMais.Repository;
using PetMais.Repository.Interfaces;
using PetMais.Services;
using System.Drawing;
using System.Windows.Forms;
using PetMais.Dominio.Notifications;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		IRepository _repositorio;

		public TelaDeVisualizacao(IRepository repositorio)
		{
			InitializeComponent();
			_repositorio = repositorio;
			PopularDados();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(_repositorio);

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
				Pet petParaEditar = _repositorio.PegarPetPeloId(id);
				TelaDeCadastro telaDeCadastro = new TelaDeCadastro(_repositorio, petParaEditar);

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
				Pet petParaRemover = _repositorio.PegarPetPeloId(id);
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
			dgvListaDePets.DataSource = _repositorio.PegarListaDePets().ToList();
		}

		void RemoverPet(int id)
		{
			_repositorio.RemoverPet(id);
		}

		void VerificarLinhasSelecionada(int linhaSelecionada)
		{
			const int unicaLinhaSelecionada = 1;
			if (linhaSelecionada > unicaLinhaSelecionada)
			{
				throw new MensagensDeErros("Selecione apenas uma linha para efetuar a edição");
			}

			if (linhaSelecionada < unicaLinhaSelecionada)
			{
				throw new MensagensDeErros("Selecione pelo menos uma linha para efetuar a edição");
			}
		}		
	}
}