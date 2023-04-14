using PetMais.Enums;
using PetMais.Services;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		public ListaDePets ListaDePets = new ListaDePets();

		public TelaDeVisualizacao()
		{
			InitializeComponent();
		}

		private void AoClicarBotaoCadastrar(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(this);

			if (telaDeCadastro.ShowDialog(this) == DialogResult.OK)
			{
				PopularDados();
			}
			else
			{
				telaDeCadastro.Close();
			}
		}

		void PopularDados()
		{
			dgvListaDePets.DataSource = null;
			dgvListaDePets.DataSource = ListaDePets.MostrarPets();
		}		
	}
}