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
			txtTipo = new TextBox();
			txtCor = new TextBox();
			cbSexo = new ComboBox();
			dtpNascimento = new DateTimePicker();
			btnCadastrar = new Button();
			btnCancelar = new Button();
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
			label3.Location = new Point(12, 154);
			label3.Name = "label3";
			label3.Size = new Size(26, 15);
			label3.TabIndex = 2;
			label3.Text = "Cor";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new Point(202, 154);
			label4.Name = "label4";
			label4.Size = new Size(32, 15);
			label4.TabIndex = 3;
			label4.Text = "Sexo";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new Point(12, 217);
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
			// txtTipo
			// 
			txtTipo.Location = new Point(12, 106);
			txtTipo.Name = "txtTipo";
			txtTipo.Size = new Size(333, 23);
			txtTipo.TabIndex = 6;
			// 
			// txtCor
			// 
			txtCor.Location = new Point(12, 172);
			txtCor.Name = "txtCor";
			txtCor.Size = new Size(147, 23);
			txtCor.TabIndex = 7;
			// 
			// cbSexo
			// 
			cbSexo.FormattingEnabled = true;
			cbSexo.Location = new Point(202, 172);
			cbSexo.Name = "cbSexo";
			cbSexo.Size = new Size(143, 23);
			cbSexo.TabIndex = 10;
			cbSexo.Text = "Escolha o sexo do pet";
			// 
			// dtpNascimento
			// 
			dtpNascimento.Location = new Point(12, 235);
			dtpNascimento.Name = "dtpNascimento";
			dtpNascimento.Size = new Size(262, 23);
			dtpNascimento.TabIndex = 11;
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
			btnCadastrar.Location = new Point(14, 294);
			btnCadastrar.Name = "btnCadastrar";
			btnCadastrar.Size = new Size(85, 27);
			btnCadastrar.TabIndex = 12;
			btnCadastrar.Text = "Adicionar";
			btnCadastrar.UseVisualStyleBackColor = false;
			btnCadastrar.Click += btnCadastrar_Click;
			// 
			// btnCancelar
			// 
			btnCancelar.BackColor = Color.Red;
			btnCancelar.BackgroundImageLayout = ImageLayout.None;
			btnCancelar.Cursor = Cursors.Hand;
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
			// TelaDeCadastro
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(357, 333);
			Controls.Add(btnCancelar);
			Controls.Add(btnCadastrar);
			Controls.Add(dtpNascimento);
			Controls.Add(cbSexo);
			Controls.Add(txtCor);
			Controls.Add(txtTipo);
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
		private TextBox txtTipo;
		private TextBox txtCor;
		private ComboBox cbSexo;
		private DateTimePicker dtpNascimento;
		private Button btnCadastrar;
		private Button btnCancelar;
	}
}