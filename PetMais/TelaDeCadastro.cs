using PetMais.Enums;
using PetMais.Repository;
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
		private Pet Pet;
		BDRepositorio bdRepositorio = new BDRepositorio();

		public TelaDeCadastro(Pet pet = null)
		{
			InitializeComponent();
			ConfigurarComboBoxesComEnums();
			Pet = pet;
		}

		private void AoClicarBotaoAdicionar(object sender, EventArgs e)
		{
			try
			{
				Pet pet;

				if (Pet != null)
				{
					EditarPet();
				}
				else
				{
					AdicionarPet();
				}

				this.DialogResult = DialogResult.OK;

			}
			catch (MensagensDeErros ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		void ConfigurarComboBoxesComEnums()
		{
			cbSexo.DataSource = Enum.GetValues(typeof(SexoPet));
			cbCor.DataSource = Enum.GetValues(typeof(CorPet));
			cbTipo.DataSource = Enum.GetValues(typeof(TipoPet));
		}

		private void TelaDeCadastro_Load(object sender, EventArgs e)
		{
			this.txtNome.Text = Pet?.Nome;
			this.cbCor.Text = Pet?.Cor.ToString();
			this.cbTipo.Text = Pet?.Tipo.ToString();
			this.cbSexo.Text = Pet?.Sexo.ToString();
			this.dtpNascimento.Value = Pet is null ? DateTime.Now : Pet.DataDeNascimento;
		}

		void PegarDados(Pet pet)
		{
			pet.Nome = txtNome.Text;
			pet.Cor = (CorPet)Enum.Parse(typeof(CorPet), cbCor.SelectedItem.ToString());
			pet.Tipo = (TipoPet)Enum.Parse(typeof(TipoPet), cbTipo.SelectedItem.ToString());
			pet.Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), cbSexo.SelectedItem.ToString());
			pet.DataDeNascimento = dtpNascimento.Value;
		}

		void AdicionarPet()
		{
			Pet novoPet = new Pet();
			PegarDados(novoPet);
			ValidarForm.ValidacaoDosCampos(novoPet);
			bdRepositorio.AdicionarPet(novoPet);
		}

		void EditarPet()
		{
			Pet petParaEditar = new Pet();
			Pet petAtual = Pet;
			petParaEditar.Id = petAtual.Id;
			petParaEditar.DataDeCadastro = petAtual.DataDeCadastro;
			PegarDados(petParaEditar);
			ValidarForm.ValidacaoDosCampos(petParaEditar);
			bdRepositorio.EditarPet(petParaEditar);
		}
	}
}