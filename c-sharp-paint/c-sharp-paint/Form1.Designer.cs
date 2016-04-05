namespace c_sharp_paint
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
            this.display = new System.Windows.Forms.Panel();
            this.colorDia = new System.Windows.Forms.ColorDialog();
            this.pickColor = new System.Windows.Forms.Button();
            this.thickness = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pickEraiser = new System.Windows.Forms.Button();
            this.figures = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // display
            // 
            this.display.BackColor = System.Drawing.Color.White;
            this.display.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.display.Location = new System.Drawing.Point(33, 36);
            this.display.MaximumSize = new System.Drawing.Size(1000, 1000);
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(322, 429);
            this.display.TabIndex = 0;
            this.display.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel_MouseDown);
            this.display.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel_MouseMove);
            this.display.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel_MouseUp);
            // 
            // colorDia
            // 
            this.colorDia.AnyColor = true;
            // 
            // pickColor
            // 
            this.pickColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickColor.Location = new System.Drawing.Point(578, 131);
            this.pickColor.Name = "pickColor";
            this.pickColor.Size = new System.Drawing.Size(121, 29);
            this.pickColor.TabIndex = 1;
            this.pickColor.Text = "Цвет";
            this.pickColor.UseVisualStyleBackColor = true;
            this.pickColor.Click += new System.EventHandler(this.pickColor_Click);
            // 
            // thickness
            // 
            this.thickness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.thickness.FormattingEnabled = true;
            this.thickness.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16",
            "20",
            "40",
            "400"});
            this.thickness.Location = new System.Drawing.Point(578, 15);
            this.thickness.Name = "thickness";
            this.thickness.Size = new System.Drawing.Size(121, 24);
            this.thickness.TabIndex = 2;
            this.thickness.Text = "14";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(434, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Толщина: ";
            // 
            // pickEraiser
            // 
            this.pickEraiser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pickEraiser.Location = new System.Drawing.Point(437, 131);
            this.pickEraiser.Name = "pickEraiser";
            this.pickEraiser.Size = new System.Drawing.Size(121, 29);
            this.pickEraiser.TabIndex = 4;
            this.pickEraiser.Text = "Ластик";
            this.pickEraiser.UseVisualStyleBackColor = true;
            this.pickEraiser.Click += new System.EventHandler(this.pickEraiser_Click);
            // 
            // figures
            // 
            this.figures.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.figures.FormattingEnabled = true;
            this.figures.Items.AddRange(new object[] {
            "circle",
            "rectangle"});
            this.figures.Location = new System.Drawing.Point(578, 47);
            this.figures.Name = "figures";
            this.figures.Size = new System.Drawing.Size(121, 24);
            this.figures.TabIndex = 5;
            this.figures.Text = "circle";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(434, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Фигура:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(437, 166);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "Многоугольник";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 555);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.figures);
            this.Controls.Add(this.pickEraiser);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.thickness);
            this.Controls.Add(this.pickColor);
            this.Controls.Add(this.display);
            this.MinimumSize = new System.Drawing.Size(700, 600);
            this.Name = "form";
            this.Text = "Paint";
            this.Resize += new System.EventHandler(this.form_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel display;
        private System.Windows.Forms.ColorDialog colorDia;
        private System.Windows.Forms.Button pickColor;
        private System.Windows.Forms.ComboBox thickness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button pickEraiser;
        private System.Windows.Forms.ComboBox figures;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}

