namespace PetMais
{
	partial class TelaDeVisualizacao
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			dgvListaDePets = new DataGridView();
			btnCadastrar = new Button();
			((System.ComponentModel.ISupportInitialize)dgvListaDePets).BeginInit();
			SuspendLayout();
			// 
			// dgvListaDePets
			// 
			dgvListaDePets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvListaDePets.Location = new Point(-2, -1);
			dgvListaDePets.Name = "dgvListaDePets";
			dgvListaDePets.RowTemplate.Height = 25;
			dgvListaDePets.Size = new Size(783, 257);
			dgvListaDePets.TabIndex = 0;
			// 
			// btnCadastrar
			// 
			btnCadastrar.BackColor = Color.LimeGreen;
			btnCadastrar.BackgroundImageLayout = ImageLayout.None;
			btnCadastrar.Cursor = Cursors.Hand;
			btnCadastrar.FlatAppearance.BorderSize = 0;
			btnCadastrar.FlatStyle = FlatStyle.Flat;
			btnCadastrar.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnCadastrar.ForeColor = SystemColors.ButtonFace;
			btnCadastrar.Location = new Point(491, 262);
			btnCadastrar.Name = "btnCadastrar";
			btnCadastrar.Size = new Size(85, 27);
			btnCadastrar.TabIndex = 1;
			btnCadastrar.Text = "Cadastrar";
			btnCadastrar.UseVisualStyleBackColor = false;
			btnCadastrar.Click += AoClicarBotaoCadastrar;
			// 
			// TelaDeVisualizacao
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(780, 297);
			Controls.Add(btnCadastrar);
			Controls.Add(dgvListaDePets);
			Name = "TelaDeVisualizacao";
			Text = "Form1";
			((System.ComponentModel.ISupportInitialize)dgvListaDePets).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private DataGridView dgvListaDePets;
		private Button btnCadastrar;
	}
}