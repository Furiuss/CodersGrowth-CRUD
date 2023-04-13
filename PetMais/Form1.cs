using PetMais.Enums;

namespace PetMais
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			var listaPets = new List<Pet>();
			listaPets.AddRange(new[]
			{
				new Pet(1, "Junior", "Gato", "Preto", SexoPet.MASCULINO, DateTime.Now, DateTime.Now),
				new Pet(2, "Max", "Cachorro", "Caramelo", SexoPet.MASCULINO, DateTime.Now, DateTime.Now),
				new Pet(3, "Judite", "Cachorro", "Branco", SexoPet.FEMININO, DateTime.Now, DateTime.Now)
			});

			this.dataGridView1.DataSource = listaPets;
		}
	}
}