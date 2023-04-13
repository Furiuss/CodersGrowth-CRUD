using PetMais.Enums;
using PetMais.Services;

namespace PetMais
{
	public partial class TelaDeVisualizacao : Form
	{
		public TelaDeVisualizacao()
		{
			InitializeComponent();
			ListaDePets listaDePets = new ListaDePets();

			this.dgvListaDePets.DataSource = listaDePets.ListaPets;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			TelaDeCadastro telaDeCadastro = new TelaDeCadastro();
			telaDeCadastro.Show();
		}
	}
}