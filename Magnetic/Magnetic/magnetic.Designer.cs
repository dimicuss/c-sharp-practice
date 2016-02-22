namespace Magnetic
{
    partial class Magnetic
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
            this.drawField = new System.Windows.Forms.PictureBox();
            this.Space = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearField = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.drawField)).BeginInit();
            this.SuspendLayout();
            // 
            // drawField
            // 
            this.drawField.BackColor = System.Drawing.SystemColors.Window;
            this.drawField.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.drawField.Location = new System.Drawing.Point(11, 23);
            this.drawField.Margin = new System.Windows.Forms.Padding(2);
            this.drawField.Name = "drawField";
            this.drawField.Size = new System.Drawing.Size(400, 400);
            this.drawField.TabIndex = 1;
            this.drawField.TabStop = false;
            this.drawField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawField_MouseDown);
            // 
            // Space
            // 
            this.Space.Location = new System.Drawing.Point(638, 20);
            this.Space.Name = "Space";
            this.Space.Size = new System.Drawing.Size(37, 20);
            this.Space.TabIndex = 6;
            this.Space.TextChanged += new System.EventHandler(this.Space_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(435, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Введите интервал между пробелами:";
            // 
            // clearField
            // 
            this.clearField.Location = new System.Drawing.Point(538, 400);
            this.clearField.Name = "clearField";
            this.clearField.Size = new System.Drawing.Size(137, 23);
            this.clearField.TabIndex = 8;
            this.clearField.Text = "Очисить поле";
            this.clearField.UseVisualStyleBackColor = true;
            this.clearField.Click += new System.EventHandler(this.clearField_Click);
            // 
            // Magnetic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(690, 448);
            this.Controls.Add(this.clearField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Space);
            this.Controls.Add(this.drawField);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximumSize = new System.Drawing.Size(706, 487);
            this.MinimumSize = new System.Drawing.Size(706, 487);
            this.Name = "Magnetic";
            this.Text = "Magnetic";
            ((System.ComponentModel.ISupportInitialize)(this.drawField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox drawField;
        private System.Windows.Forms.TextBox Space;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearField;
    }
}

