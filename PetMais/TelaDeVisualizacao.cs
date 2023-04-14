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

		private void button1_Click(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro(this);
			telaDeCadastro.ShowDialog();
			PopularDados();
		}

		void PopularDados()
		{
			dgvListaDePets.DataSource = null;
			dgvListaDePets.DataSource = ListaDePets.MostrarPets();
		}
	}
}