namespace calculator
{
    partial class display
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
            this.field = new System.Windows.Forms.TextBox();
            this.count = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // field
            // 
            this.field.Location = new System.Drawing.Point(78, 99);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(353, 22);
            this.field.TabIndex = 0;
            // 
            // count
            // 
            this.count.Location = new System.Drawing.Point(224, 256);
            this.count.Name = "count";
            this.count.Size = new System.Drawing.Size(75, 23);
            this.count.TabIndex = 1;
            this.count.Text = "Count";
            this.count.UseVisualStyleBackColor = true;
            this.count.Click += new System.EventHandler(this.count_Click);
            // 
            // display
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 431);
            this.Controls.Add(this.count);
            this.Controls.Add(this.field);
            this.Name = "display";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox field;
        private System.Windows.Forms.Button count;
    }
}

