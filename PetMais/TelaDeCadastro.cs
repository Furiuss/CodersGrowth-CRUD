using PetMais.Enums;
using PetMais.Repository;
using PetMais.Repository.Interfaces;
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
		private Pet _pet;
		IRepository _repositorio;

		public TelaDeCadastro(IRepository repositorio, Pet pet = null)
		{
			InitializeComponent();
			ConfigurarComboBoxesComEnums();
			_pet = pet;
			_repositorio = repositorio;
		}

		private void AoClicarBotaoAdicionar(object sender, EventArgs e)
		{
			try
			{

				if (_pet != null)
				{
					EditarPet();
				}
				else
				{
					AdicionarPet();
				}

				this.DialogResult = DialogResult.OK;

			}
			catch (Exception ex)
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
			this.txtNome.Text = _pet?.Nome;
			this.cbCor.Text = _pet?.Cor.ToString();
			this.cbTipo.Text = _pet?.Tipo.ToString();
			this.cbSexo.Text = _pet?.Sexo.ToString();
			this.dtpNascimento.Value = _pet is null ? DateTime.Now : _pet.DataDeNascimento;
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
			_repositorio.AdicionarPet(novoPet);
		}

		void EditarPet()
		{
			Pet petParaEditar = new Pet();
			Pet petAtual = _pet;
			petParaEditar.Id = petAtual.Id;
			petParaEditar.DataDeCadastro = petAtual.DataDeCadastro;
			PegarDados(petParaEditar);
			ValidarForm.ValidacaoDosCampos(petParaEditar);
			_repositorio.EditarPet(petParaEditar);
		}
	}
}