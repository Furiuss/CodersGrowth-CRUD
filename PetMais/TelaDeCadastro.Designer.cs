namespace PetMais
{
	partial class TelaDeCadastro
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			label2 = new Label();
			label3 = new Label();
			label4 = new Label();
			label5 = new Label();
			txtNome = new TextBox();
			cbSexo = new ComboBox();
			dtpNascimento = new DateTimePicker();
			btnAdicionar = new Button();
			btnCancelar = new Button();
			cbTipo = new ComboBox();
			cbCor = new ComboBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 33);
			label1.Name = "label1";
			label1.Size = new Size(40, 15);
			label1.TabIndex = 0;
			label1.Text = "Nome";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(12, 88);
			label2.Name = "label2";
			label2.Size = new Size(87, 15);
			label2.TabIndex = 1;
			label2.Text = "Tipo de Animal";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(187, 88);
			label3.Name = "label3";
			label3.Size = new Size(26, 15);
			label3.TabIndex = 2;
			label3.Text = "Cor";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(14, 149);
			label4.Name = "label4";
			label4.Size = new Size(32, 15);
			label4.TabIndex = 3;
			label4.Text = "Sexo";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 212);
			label5.Name = "label5";
			label5.Size = new Size(114, 15);
			label5.TabIndex = 4;
			label5.Text = "Data de Nascimento";
			// 
			// txtNome
			// 
			txtNome.Location = new Point(12, 51);
			txtNome.Name = "txtNome";
			txtNome.Size = new Size(333, 23);
			txtNome.TabIndex = 5;
			// 
			// cbSexo
			// 
			cbSexo.FormattingEnabled = true;
			cbSexo.Location = new Point(16, 167);
			cbSexo.Name = "cbSexo";
			cbSexo.Size = new Size(160, 23);
			cbSexo.TabIndex = 10;
			cbSexo.Text = "Escolha o sexo do pet";
			// 
			// dtpNascimento
			// 
			dtpNascimento.Location = new Point(12, 230);
			dtpNascimento.Name = "dtpNascimento";
			dtpNascimento.Size = new Size(252, 23);
			dtpNascimento.TabIndex = 11;
			// 
			// btnAdicionar
			// 
			btnAdicionar.BackColor = Color.LimeGreen;
			btnAdicionar.BackgroundImageLayout = ImageLayout.None;
			btnAdicionar.Cursor = Cursors.Hand;
			btnAdicionar.FlatAppearance.BorderSize = 0;
			btnAdicionar.FlatStyle = FlatStyle.Flat;
			btnAdicionar.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnAdicionar.ForeColor = SystemColors.ButtonFace;
			btnAdicionar.Location = new Point(14, 294);
			btnAdicionar.Name = "btnAdicionar";
			btnAdicionar.Size = new Size(85, 27);
			btnAdicionar.TabIndex = 12;
			btnAdicionar.Text = "Adicionar";
			btnAdicionar.UseVisualStyleBackColor = false;
			btnAdicionar.Click += AoClicarBotaoAdicionar;
			// 
			// btnCancelar
			// 
			btnCancelar.BackColor = Color.Red;
			btnCancelar.BackgroundImageLayout = ImageLayout.None;
			btnCancelar.Cursor = Cursors.Hand;
			btnCancelar.DialogResult = DialogResult.Cancel;
			btnCancelar.FlatAppearance.BorderSize = 0;
			btnCancelar.FlatStyle = FlatStyle.Flat;
			btnCancelar.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			btnCancelar.ForeColor = SystemColors.ButtonFace;
			btnCancelar.Location = new Point(260, 294);
			btnCancelar.Name = "btnCancelar";
			btnCancelar.Size = new Size(85, 27);
			btnCancelar.TabIndex = 13;
			btnCancelar.Text = "Cancelar";
			btnCancelar.UseVisualStyleBackColor = false;
			// 
			// cbTipo
			// 
			cbTipo.FormattingEnabled = true;
			cbTipo.Location = new Point(18, 106);
			cbTipo.Name = "cbTipo";
			cbTipo.Size = new Size(158, 23);
			cbTipo.TabIndex = 14;
			cbTipo.Text = "Escolha o tipo de pet";
			// 
			// cbCor
			// 
			cbCor.FormattingEnabled = true;
			cbCor.Location = new Point(187, 106);
			cbCor.Name = "cbCor";
			cbCor.Size = new Size(158, 23);
			cbCor.TabIndex = 15;
			cbCor.Text = "Escolha a cor do pet";
			// 
			// TelaDeCadastro
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(357, 333);
			Controls.Add(cbCor);
			Controls.Add(cbTipo);
			Controls.Add(btnCancelar);
			Controls.Add(btnAdicionar);
			Controls.Add(dtpNascimento);
			Controls.Add(cbSexo);
			Controls.Add(txtNome);
			Controls.Add(label5);
			Controls.Add(label4);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "TelaDeCadastro";
			Text = "TelaDeCadastro";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private Label label3;
		private Label label4;
		private Label label5;
		private TextBox txtNome;
		private TextBox txtCor;
		private ComboBox cbSexo;
		private DateTimePicker dtpNascimento;
		private Button btnAdicionar;
		private Button btnCancelar;
		private ComboBox cbTipo;
		private ComboBox cbCor;
	}
}