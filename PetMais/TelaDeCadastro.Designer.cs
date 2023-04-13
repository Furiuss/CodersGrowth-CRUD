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
			textBox1 = new TextBox();
			textBox2 = new TextBox();
			textBox3 = new TextBox();
			comboBox1 = new ComboBox();
			dateTimePicker1 = new DateTimePicker();
			btnCadastrar = new Button();
			button1 = new Button();
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
			// textBox1
			// 
			textBox1.Location = new Point(12, 51);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(333, 23);
			textBox1.TabIndex = 5;
			// 
			// textBox2
			// 
			textBox2.Location = new Point(12, 106);
			textBox2.Name = "textBox2";
			textBox2.Size = new Size(333, 23);
			textBox2.TabIndex = 6;
			// 
			// textBox3
			// 
			textBox3.Location = new Point(12, 172);
			textBox3.Name = "textBox3";
			textBox3.Size = new Size(147, 23);
			textBox3.TabIndex = 7;
			// 
			// comboBox1
			// 
			comboBox1.FormattingEnabled = true;
			comboBox1.Items.AddRange(new object[] { "Macho", "Fêmea" });
			comboBox1.Location = new Point(202, 172);
			comboBox1.Name = "comboBox1";
			comboBox1.Size = new Size(143, 23);
			comboBox1.TabIndex = 10;
			comboBox1.Text = "Escolha o sexo do pet";
			// 
			// dateTimePicker1
			// 
			dateTimePicker1.Location = new Point(12, 235);
			dateTimePicker1.Name = "dateTimePicker1";
			dateTimePicker1.Size = new Size(262, 23);
			dateTimePicker1.TabIndex = 11;
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
			// button1
			// 
			button1.BackColor = Color.Red;
			button1.BackgroundImageLayout = ImageLayout.None;
			button1.Cursor = Cursors.Hand;
			button1.FlatAppearance.BorderSize = 0;
			button1.FlatStyle = FlatStyle.Flat;
			button1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point);
			button1.ForeColor = SystemColors.ButtonFace;
			button1.Location = new Point(260, 294);
			button1.Name = "button1";
			button1.Size = new Size(85, 27);
			button1.TabIndex = 13;
			button1.Text = "Cancelar";
			button1.UseVisualStyleBackColor = false;
			// 
			// TelaDeCadastro
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(357, 333);
			Controls.Add(button1);
			Controls.Add(btnCadastrar);
			Controls.Add(dateTimePicker1);
			Controls.Add(comboBox1);
			Controls.Add(textBox3);
			Controls.Add(textBox2);
			Controls.Add(textBox1);
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
		private TextBox textBox1;
		private TextBox textBox2;
		private TextBox textBox3;
		private ComboBox comboBox1;
		private DateTimePicker dateTimePicker1;
		private Button btnCadastrar;
		private Button button1;
	}
}