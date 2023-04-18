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
			btnEditar = new Button();
			btnRemover = new Button();
			((System.ComponentModel.ISupportInitialize)dgvListaDePets).BeginInit();
			SuspendLayout();
			// 
			// dgvListaDePets
			// 
			dgvListaDePets.AllowUserToAddRows = false;
			dgvListaDePets.AllowUserToDeleteRows = false;
			dgvListaDePets.AllowUserToResizeColumns = false;
			dgvListaDePets.AllowUserToResizeRows = false;
			dgvListaDePets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvListaDePets.Location = new Point(-2, -1);
			dgvListaDePets.Name = "dgvListaDePets";
			dgvListaDePets.ReadOnly = true;
			dgvListaDePets.RowHeadersWidth = 62;
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
			btnCadastrar.Location = new Point(461, 262);
			btnCadastrar.Name = "btnCadastrar";
			btnCadastrar.Size = new Size(85, 27);
			btnCadastrar.TabIndex = 1;
			btnCadastrar.Text = "Cadastrar";
			btnCadastrar.UseVisualStyleBackColor = false;
			btnCadastrar.Click += AoClicarBotaoCadastrar;
			// 
			// btnEditar
			// 
			btnEditar.BackColor = Color.DarkOrange;
			btnEditar.BackgroundImageLayout = ImageLayout.None;
			btnEditar.Cursor = Cursors.Hand;
			btnEditar.FlatAppearance.BorderSize = 0;
			btnEditar.FlatStyle = FlatStyle.Flat;
			btnEditar.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnEditar.ForeColor = SystemColors.ButtonFace;
			btnEditar.Location = new Point(566, 262);
			btnEditar.Name = "btnEditar";
			btnEditar.Size = new Size(85, 27);
			btnEditar.TabIndex = 2;
			btnEditar.Text = "Editar";
			btnEditar.UseVisualStyleBackColor = false;
			btnEditar.Click += AoClicarNoBotaoEditar;
			// 
			// btnRemover
			// 
			btnRemover.BackColor = Color.Red;
			btnRemover.BackgroundImageLayout = ImageLayout.None;
			btnRemover.Cursor = Cursors.Hand;
			btnRemover.FlatAppearance.BorderSize = 0;
			btnRemover.FlatStyle = FlatStyle.Flat;
			btnRemover.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnRemover.ForeColor = SystemColors.ButtonFace;
			btnRemover.Location = new Point(672, 262);
			btnRemover.Name = "btnRemover";
			btnRemover.Size = new Size(85, 27);
			btnRemover.TabIndex = 3;
			btnRemover.Text = "Remover";
			btnRemover.UseVisualStyleBackColor = false;
			btnRemover.Click += AoClicarNoBotaoRemover;
			// 
			// TelaDeVisualizacao
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(780, 297);
			Controls.Add(btnRemover);
			Controls.Add(btnEditar);
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
		private Button btnEditar;
		private Button btnRemover;
	}
}
