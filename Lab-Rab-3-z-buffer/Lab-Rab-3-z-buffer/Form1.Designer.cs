namespace Lab_Rab_3_z_buffer
{
    partial class Form
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.drawButton = new System.Windows.Forms.Button();
            this.aM11 = new System.Windows.Forms.TextBox();
            this.aM12 = new System.Windows.Forms.TextBox();
            this.aM13 = new System.Windows.Forms.TextBox();
            this.aM21 = new System.Windows.Forms.TextBox();
            this.aM22 = new System.Windows.Forms.TextBox();
            this.aM23 = new System.Windows.Forms.TextBox();
            this.aM32 = new System.Windows.Forms.TextBox();
            this.aM33 = new System.Windows.Forms.TextBox();
            this.aM31 = new System.Windows.Forms.TextBox();
            this.bM11 = new System.Windows.Forms.TextBox();
            this.bM12 = new System.Windows.Forms.TextBox();
            this.bM13 = new System.Windows.Forms.TextBox();
            this.bM21 = new System.Windows.Forms.TextBox();
            this.bM22 = new System.Windows.Forms.TextBox();
            this.bM23 = new System.Windows.Forms.TextBox();
            this.bM31 = new System.Windows.Forms.TextBox();
            this.bM32 = new System.Windows.Forms.TextBox();
            this.bM33 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.image = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pickColor1 = new System.Windows.Forms.Button();
            this.pickColor2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.SuspendLayout();
            // 
            // drawButton
            // 
            this.drawButton.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.drawButton.Location = new System.Drawing.Point(722, 617);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 0;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // aM11
            // 
            this.aM11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM11.Location = new System.Drawing.Point(604, 87);
            this.aM11.Name = "aM11";
            this.aM11.Size = new System.Drawing.Size(32, 22);
            this.aM11.TabIndex = 1;
            // 
            // aM12
            // 
            this.aM12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM12.Location = new System.Drawing.Point(666, 87);
            this.aM12.Name = "aM12";
            this.aM12.Size = new System.Drawing.Size(32, 22);
            this.aM12.TabIndex = 2;
            // 
            // aM13
            // 
            this.aM13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM13.Location = new System.Drawing.Point(727, 87);
            this.aM13.Name = "aM13";
            this.aM13.Size = new System.Drawing.Size(32, 22);
            this.aM13.TabIndex = 3;
            // 
            // aM21
            // 
            this.aM21.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM21.Location = new System.Drawing.Point(604, 136);
            this.aM21.Name = "aM21";
            this.aM21.Size = new System.Drawing.Size(32, 22);
            this.aM21.TabIndex = 6;
            // 
            // aM22
            // 
            this.aM22.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM22.Location = new System.Drawing.Point(666, 136);
            this.aM22.Name = "aM22";
            this.aM22.Size = new System.Drawing.Size(32, 22);
            this.aM22.TabIndex = 5;
            // 
            // aM23
            // 
            this.aM23.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM23.Location = new System.Drawing.Point(727, 136);
            this.aM23.Name = "aM23";
            this.aM23.Size = new System.Drawing.Size(32, 22);
            this.aM23.TabIndex = 4;
            // 
            // aM32
            // 
            this.aM32.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM32.Location = new System.Drawing.Point(666, 185);
            this.aM32.Name = "aM32";
            this.aM32.Size = new System.Drawing.Size(32, 22);
            this.aM32.TabIndex = 12;
            // 
            // aM33
            // 
            this.aM33.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM33.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM33.Location = new System.Drawing.Point(727, 185);
            this.aM33.Name = "aM33";
            this.aM33.Size = new System.Drawing.Size(32, 22);
            this.aM33.TabIndex = 11;
            // 
            // aM31
            // 
            this.aM31.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.aM31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.aM31.Location = new System.Drawing.Point(604, 185);
            this.aM31.Name = "aM31";
            this.aM31.Size = new System.Drawing.Size(32, 22);
            this.aM31.TabIndex = 10;
            // 
            // bM11
            // 
            this.bM11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM11.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM11.Location = new System.Drawing.Point(604, 348);
            this.bM11.Name = "bM11";
            this.bM11.Size = new System.Drawing.Size(32, 22);
            this.bM11.TabIndex = 21;
            // 
            // bM12
            // 
            this.bM12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM12.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM12.Location = new System.Drawing.Point(666, 348);
            this.bM12.Name = "bM12";
            this.bM12.Size = new System.Drawing.Size(32, 22);
            this.bM12.TabIndex = 20;
            // 
            // bM13
            // 
            this.bM13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM13.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM13.Location = new System.Drawing.Point(727, 348);
            this.bM13.Name = "bM13";
            this.bM13.Size = new System.Drawing.Size(32, 22);
            this.bM13.TabIndex = 19;
            // 
            // bM21
            // 
            this.bM21.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM21.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM21.Location = new System.Drawing.Point(604, 397);
            this.bM21.Name = "bM21";
            this.bM21.Size = new System.Drawing.Size(32, 22);
            this.bM21.TabIndex = 18;
            // 
            // bM22
            // 
            this.bM22.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM22.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM22.Location = new System.Drawing.Point(666, 397);
            this.bM22.Name = "bM22";
            this.bM22.Size = new System.Drawing.Size(32, 22);
            this.bM22.TabIndex = 17;
            // 
            // bM23
            // 
            this.bM23.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM23.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM23.Location = new System.Drawing.Point(727, 397);
            this.bM23.Name = "bM23";
            this.bM23.Size = new System.Drawing.Size(32, 22);
            this.bM23.TabIndex = 16;
            // 
            // bM31
            // 
            this.bM31.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM31.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM31.Location = new System.Drawing.Point(604, 446);
            this.bM31.Name = "bM31";
            this.bM31.Size = new System.Drawing.Size(32, 22);
            this.bM31.TabIndex = 15;
            // 
            // bM32
            // 
            this.bM32.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM32.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM32.Location = new System.Drawing.Point(666, 446);
            this.bM32.Name = "bM32";
            this.bM32.Size = new System.Drawing.Size(32, 22);
            this.bM32.TabIndex = 14;
            // 
            // bM33
            // 
            this.bM33.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.bM33.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.bM33.Location = new System.Drawing.Point(727, 446);
            this.bM33.Name = "bM33";
            this.bM33.Size = new System.Drawing.Size(32, 22);
            this.bM33.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(538, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "M 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(538, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "M 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label3.Location = new System.Drawing.Point(538, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "M 3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label4.Location = new System.Drawing.Point(538, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 27;
            this.label4.Text = "M 3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label5.Location = new System.Drawing.Point(538, 399);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "M 2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label6.Location = new System.Drawing.Point(538, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "M 1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label7.Location = new System.Drawing.Point(601, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 28;
            this.label7.Text = "A Flat";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(605, 311);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 17);
            this.label8.TabIndex = 29;
            this.label8.Text = "B Flat";
            // 
            // image
            // 
            this.image.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.image.Location = new System.Drawing.Point(17, 30);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(495, 495);
            this.image.TabIndex = 30;
            this.image.TabStop = false;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // pickColor1
            // 
            this.pickColor1.Location = new System.Drawing.Point(649, 248);
            this.pickColor1.Name = "pickColor1";
            this.pickColor1.Size = new System.Drawing.Size(110, 23);
            this.pickColor1.TabIndex = 31;
            this.pickColor1.Text = "Pick Color";
            this.pickColor1.UseVisualStyleBackColor = true;
            this.pickColor1.Click += new System.EventHandler(this.pickColor1_Click);
            // 
            // pickColor2
            // 
            this.pickColor2.Location = new System.Drawing.Point(649, 502);
            this.pickColor2.Name = "pickColor2";
            this.pickColor2.Size = new System.Drawing.Size(110, 23);
            this.pickColor2.TabIndex = 32;
            this.pickColor2.Text = "Pick Color";
            this.pickColor2.UseVisualStyleBackColor = true;
            this.pickColor2.Click += new System.EventHandler(this.pickColor2_Click);
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(809, 652);
            this.Controls.Add(this.pickColor2);
            this.Controls.Add(this.pickColor1);
            this.Controls.Add(this.image);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bM11);
            this.Controls.Add(this.bM12);
            this.Controls.Add(this.bM13);
            this.Controls.Add(this.bM21);
            this.Controls.Add(this.bM22);
            this.Controls.Add(this.bM23);
            this.Controls.Add(this.bM31);
            this.Controls.Add(this.bM32);
            this.Controls.Add(this.bM33);
            this.Controls.Add(this.aM32);
            this.Controls.Add(this.aM33);
            this.Controls.Add(this.aM31);
            this.Controls.Add(this.aM21);
            this.Controls.Add(this.aM22);
            this.Controls.Add(this.aM23);
            this.Controls.Add(this.aM13);
            this.Controls.Add(this.aM12);
            this.Controls.Add(this.aM11);
            this.Controls.Add(this.drawButton);
            this.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.Name = "Form";
            this.Text = "Z-Buffer";
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox aM11;
        private System.Windows.Forms.TextBox aM12;
        private System.Windows.Forms.TextBox aM13;
        private System.Windows.Forms.TextBox aM21;
        private System.Windows.Forms.TextBox aM22;
        private System.Windows.Forms.TextBox aM23;
        private System.Windows.Forms.TextBox aM32;
        private System.Windows.Forms.TextBox aM33;
        private System.Windows.Forms.TextBox aM31;
        private System.Windows.Forms.TextBox bM11;
        private System.Windows.Forms.TextBox bM12;
        private System.Windows.Forms.TextBox bM13;
        private System.Windows.Forms.TextBox bM21;
        private System.Windows.Forms.TextBox bM22;
        private System.Windows.Forms.TextBox bM23;
        private System.Windows.Forms.TextBox bM31;
        private System.Windows.Forms.TextBox bM32;
        private System.Windows.Forms.TextBox bM33;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button pickColor1;
        private System.Windows.Forms.Button pickColor2;
    }
}

