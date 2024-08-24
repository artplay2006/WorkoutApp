namespace up
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox3 = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            checkBox1 = new CheckBox();
            pictureBox1 = new PictureBox();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Impact", 48F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(12, 33);
            label1.Name = "label1";
            label1.Size = new Size(168, 80);
            label1.TabIndex = 0;
            label1.Text = "вход";
            label1.Click += label1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(68, 170);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(265, 23);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.Highlight;
            label2.Location = new Point(12, 141);
            label2.Name = "label2";
            label2.Size = new Size(65, 26);
            label2.TabIndex = 2;
            label2.Text = "логин";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.Highlight;
            label3.Location = new Point(12, 253);
            label3.Name = "label3";
            label3.Size = new Size(79, 26);
            label3.TabIndex = 3;
            label3.Text = "пароль";
            label3.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(68, 282);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(265, 23);
            textBox2.TabIndex = 4;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button1
            // 
            button1.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.DarkOrange;
            button1.Location = new Point(678, 12);
            button1.Name = "button1";
            button1.Size = new Size(110, 29);
            button1.TabIndex = 5;
            button1.Text = "регистрация";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button2.ForeColor = Color.DarkOrange;
            button2.Location = new Point(678, 529);
            button2.Name = "button2";
            button2.Size = new Size(110, 41);
            button2.TabIndex = 6;
            button2.Text = "продолжить";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Enabled = false;
            label4.Location = new Point(68, 196);
            label4.Name = "label4";
            label4.Size = new Size(245, 15);
            label4.TabIndex = 7;
            label4.Text = "от 3 до 16 символов английского алфавита";
            label4.Visible = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Enabled = false;
            label5.Location = new Point(68, 308);
            label5.Name = "label5";
            label5.Size = new Size(314, 15);
            label5.TabIndex = 8;
            label5.Text = "от 5 до 16 символов английского алфавита и/или цифр";
            label5.Visible = false;
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.Highlight;
            label6.Location = new Point(12, 358);
            label6.Name = "label6";
            label6.Size = new Size(179, 26);
            label6.TabIndex = 9;
            label6.Text = "повторите пароль";
            label6.Visible = false;
            label6.Click += label6_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(68, 387);
            textBox3.Name = "textBox3";
            textBox3.PasswordChar = '*';
            textBox3.Size = new Size(265, 23);
            textBox3.TabIndex = 10;
            textBox3.Visible = false;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(86, 478);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(117, 19);
            checkBox1.TabIndex = 11;
            checkBox1.Text = "показать пароль";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(409, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 585);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // button3
            // 
            button3.Font = new Font("Impact", 12F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.DarkOrange;
            button3.Location = new Point(12, 529);
            button3.Name = "button3";
            button3.Size = new Size(110, 41);
            button3.TabIndex = 13;
            button3.Text = "выход";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            ClientSize = new Size(800, 583);
            ControlBox = false;
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(textBox3);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private Button button1;
        private Button button2;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private CheckBox checkBox1;
        private PictureBox pictureBox1;
        private Button button3;
    }
}