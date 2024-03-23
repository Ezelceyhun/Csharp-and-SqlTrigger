namespace CreateLogin_and_Login
{
    partial class CreateUser
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
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            label2 = new Label();
            label3 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            button2 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(92, 30);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(221, 34);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(12, 31);
            label1.Name = "label1";
            label1.Size = new Size(61, 23);
            label1.TabIndex = 1;
            label1.Text = "Adınız:";
            // 
            // button1
            // 
            button1.Location = new Point(136, 148);
            button1.Name = "button1";
            button1.Size = new Size(86, 37);
            button1.TabIndex = 2;
            button1.Text = "Kayıt Ol";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(13, 74);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 3;
            label2.Text = "E-Mail:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(17, 114);
            label3.Name = "label3";
            label3.Size = new Size(47, 23);
            label3.TabIndex = 4;
            label3.Text = "Şifre:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(92, 68);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(221, 34);
            textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(92, 108);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(221, 34);
            textBox3.TabIndex = 0;
            // 
            // button2
            // 
            button2.Location = new Point(228, 148);
            button2.Name = "button2";
            button2.Size = new Size(86, 37);
            button2.TabIndex = 5;
            button2.Text = "Geri Dön";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // CreateUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(365, 242);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "CreateUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateUser";
            Load += CreateUser_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Label label2;
        private Label label3;
        private TextBox textBox2;
        private TextBox textBox3;
        private Button button2;
    }
}