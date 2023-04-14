using PetMais.Enums;
using PetMais.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PetMais
{
	public partial class TelaDeCadastro : Form
	{

		public TelaDeVisualizacao telaDeVisualizacao;

		public TelaDeCadastro(TelaDeVisualizacao tv)
		{
			InitializeComponent();
			cbSexo.DataSource = Enum.GetValues(typeof(SexoPet));
			telaDeVisualizacao = tv;
		}

		private void btnCadastrar_Click(object sender, EventArgs e)
		{
			//Pet pet1 = new Pet("Joao", "Preto", "Cachorro", Enums.SexoPet.MASCULINO, DateTime.Now);
			//Pet pet2 = new Pet("Marta", "Branco", "Gato", Enums.SexoPet.FEMININO, DateTime.Now);
			//telaDeVisualizacao.ListaDePets.AdicionarPet(pet1);
			//telaDeVisualizacao.ListaDePets.AdicionarPet(pet2);

			var novoPet = new Pet()
			{
				Nome = txtNome.Text,
				Cor = txtCor.Text,
				Tipo = txtTipo.Text,
				Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), cbSexo.SelectedItem.ToString()),
				DataDeNascimento = dtpNascimento.Value
			};
			telaDeVisualizacao.ListaDePets.AdicionarPet(novoPet);

			this.Close();
		}
	}
}
