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

		private List<Pet> Pets;
		private Pet PetASerEditado;


		public TelaDeCadastro(List<Pet> pets, Pet petASerEditado = null)
		{
			InitializeComponent();
			ConfigurarComboBoxesComEnums();
			Pets = pets;
			PetASerEditado = petASerEditado;
		}

		private void AoClicarBotaoAdicionar(object sender, EventArgs e)
		{
			try
			{
				Pet pet;
				bool isUpdate = false;

				if (PetASerEditado != null)
				{
					pet = PegarPetPeloId(PetASerEditado.Id);
					isUpdate = true;
				}
				else
				{
					pet = new();
				}

				pet.Nome = txtNome.Text;
				pet.Cor = (CorPet)Enum.Parse(typeof(CorPet), cbCor.SelectedItem.ToString());
				pet.Tipo = (TipoPet)Enum.Parse(typeof(TipoPet), cbTipo.SelectedItem.ToString());
				pet.Sexo = (SexoPet)Enum.Parse(typeof(SexoPet), cbSexo.SelectedItem.ToString());
				pet.DataDeNascimento = dtpNascimento.Value;
				ValidarForm.ValidacaoDosCampos(pet);

				if (isUpdate)
				{
					EditarPet(pet);
				}
				else
				{
					AdicionarPet(pet);
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
			this.txtNome.Text = PetASerEditado?.Nome;
			this.cbCor.Text = PetASerEditado?.Cor.ToString();
			this.cbTipo.Text = PetASerEditado?.Tipo.ToString();
			this.cbSexo.Text = PetASerEditado?.Sexo.ToString();
			this.dtpNascimento.Value = PetASerEditado is null ? DateTime.Now : PetASerEditado.DataDeNascimento;
		}

		Pet PegarPetPeloId(int id)
		{
			Pet pet = Pets.FirstOrDefault(i => i.Id == id);

			if (pet == null)
			{
				return null;
			}

			return pet;
		}

		void AdicionarPet(Pet pet)
		{
			int idGerado = AutoIncrementoDeId();
			DateTime dataDeCadastro = DateTime.Now;

			pet.Id = idGerado;
			pet.DataDeCadastro = dataDeCadastro;
			Pets.Add(pet);
		}

		void EditarPet(Pet pet)
		{
			Pet PetASerEditado = PegarPetPeloId(pet.Id);
			PetASerEditado = pet;
		}

		int AutoIncrementoDeId()
		{
			if (Pets.Count > 0)
			{
				return Pets.Max(pet => pet.Id) + 1;
			}
			else
			{
				return 1;
			}
		}
	}
}
