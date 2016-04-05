namespace Lab_Rab_2_Flat_fill
{
    partial class form
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.randButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(135, 36);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(345, 362);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(227, 459);
            this.trackBar.Maximum = 270;
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(194, 56);
            this.trackBar.TabIndex = 3;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // randButton
            // 
            this.randButton.Location = new System.Drawing.Point(490, 480);
            this.randButton.Name = "randButton";
            this.randButton.Size = new System.Drawing.Size(75, 23);
            this.randButton.TabIndex = 4;
            this.randButton.Text = "Random";
            this.randButton.UseVisualStyleBackColor = true;
            this.randButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 551);
            this.Controls.Add(this.randButton);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.pictureBox);
            this.Name = "form";
            this.Text = "LR2";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.Button randButton;
    }
}

