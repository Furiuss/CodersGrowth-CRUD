using PetMais.Enums;
using PetMais.Services;

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

			if (telaDeCadastro.ShowDialog(this) == DialogResult.OK)
			{
				PopularDados();
			}
		}

		void PopularDados()
		{
			dgvListaDePets.DataSource = null;
			dgvListaDePets.DataSource = ListaDePets.MostrarPets();
		}		
	}
}