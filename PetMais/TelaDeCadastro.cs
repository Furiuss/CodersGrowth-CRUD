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

		private ListaDePets ListaDePets;

		public TelaDeCadastro(ListaDePets listaDePets)
		{
			InitializeComponent();
			cbSexo.DataSource = Enum.GetValues(typeof(SexoPet));
			ListaDePets = listaDePets;
		}

		private void AoClicarBotaoAdicionar(object sender, EventArgs e)
		{
			var novoPet = new Pet()
			{
				Nome = txtNome.Text,
				Cor = txtCor.Text,
				Tipo = txtTipo.Text,
				Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), cbSexo.SelectedItem.ToString()),
				DataDeNascimento = dtpNascimento.Value
			};
			ListaDePets.AdicionarPet(novoPet);

			this.Close();
		}
	}
}
