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
            this.button = new System.Windows.Forms.Button();
            this.drawField = new System.Windows.Forms.PictureBox();
            this.pLeftX = new System.Windows.Forms.TextBox();
            this.pLeftY = new System.Windows.Forms.TextBox();
            this.pRightX = new System.Windows.Forms.TextBox();
            this.pRightY = new System.Windows.Forms.TextBox();
            this.Space = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.drawField)).BeginInit();
            this.SuspendLayout();
            // 
            // button
            // 
            this.button.Location = new System.Drawing.Point(623, 418);
            this.button.Margin = new System.Windows.Forms.Padding(2);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(56, 19);
            this.button.TabIndex = 0;
            this.button.Text = "Кнопка";
            this.button.UseVisualStyleBackColor = true;
            this.button.Click += new System.EventHandler(this.button_Click);
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
            // 
            // pLeftX
            // 
            this.pLeftX.BackColor = System.Drawing.SystemColors.Window;
            this.pLeftX.Location = new System.Drawing.Point(573, 24);
            this.pLeftX.Name = "pLeftX";
            this.pLeftX.Size = new System.Drawing.Size(44, 20);
            this.pLeftX.TabIndex = 2;
            // 
            // pLeftY
            // 
            this.pLeftY.Location = new System.Drawing.Point(623, 24);
            this.pLeftY.Name = "pLeftY";
            this.pLeftY.Size = new System.Drawing.Size(44, 20);
            this.pLeftY.TabIndex = 3;
            // 
            // pRightX
            // 
            this.pRightX.Location = new System.Drawing.Point(573, 50);
            this.pRightX.Name = "pRightX";
            this.pRightX.Size = new System.Drawing.Size(44, 20);
            this.pRightX.TabIndex = 4;
            // 
            // pRightY
            // 
            this.pRightY.Location = new System.Drawing.Point(623, 50);
            this.pRightY.Name = "pRightY";
            this.pRightY.Size = new System.Drawing.Size(44, 20);
            this.pRightY.TabIndex = 5;
            // 
            // Space
            // 
            this.Space.Location = new System.Drawing.Point(630, 100);
            this.Space.Name = "Space";
            this.Space.Size = new System.Drawing.Size(37, 20);
            this.Space.TabIndex = 6;
            this.Space.TextChanged += new System.EventHandler(this.Space_TextChanged);
            // 
            // Magnetic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(690, 448);
            this.Controls.Add(this.Space);
            this.Controls.Add(this.pRightY);
            this.Controls.Add(this.pRightX);
            this.Controls.Add(this.pLeftY);
            this.Controls.Add(this.pLeftX);
            this.Controls.Add(this.drawField);
            this.Controls.Add(this.button);
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

        private System.Windows.Forms.Button button;
        private System.Windows.Forms.PictureBox drawField;
        private System.Windows.Forms.TextBox pLeftX;
        private System.Windows.Forms.TextBox pLeftY;
        private System.Windows.Forms.TextBox pRightX;
        private System.Windows.Forms.TextBox pRightY;
        private System.Windows.Forms.TextBox Space;
    }
}

