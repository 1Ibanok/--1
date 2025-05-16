namespace PR1
{
    partial class CalculationsForm
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
            back = new Button();
            material = new ComboBox();
            calcBtn = new Button();
            count = new TextBox();
            label1 = new Label();
            materialsList = new TextBox();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // back
            // 
            back.BackColor = Color.FromArgb(103, 186, 128);
            back.Font = new Font("Segoe UI", 9F);
            back.ForeColor = Color.White;
            back.Location = new Point(184, 197);
            back.Margin = new Padding(3, 2, 3, 2);
            back.Name = "back";
            back.Size = new Size(79, 24);
            back.TabIndex = 8;
            back.Text = "Назад";
            back.UseVisualStyleBackColor = false;
            back.Click += back_Click;
            // 
            // material
            // 
            material.FormattingEnabled = true;
            material.Location = new Point(12, 27);
            material.Name = "material";
            material.Size = new Size(250, 23);
            material.TabIndex = 9;
            // 
            // calcBtn
            // 
            calcBtn.BackColor = Color.FromArgb(103, 186, 128);
            calcBtn.Font = new Font("Segoe UI", 9F);
            calcBtn.ForeColor = Color.White;
            calcBtn.Location = new Point(12, 197);
            calcBtn.Margin = new Padding(3, 2, 3, 2);
            calcBtn.Name = "calcBtn";
            calcBtn.Size = new Size(166, 24);
            calcBtn.TabIndex = 10;
            calcBtn.Text = "Рассчитать количество";
            calcBtn.UseVisualStyleBackColor = false;
            calcBtn.Click += calcBtn_Click;
            // 
            // count
            // 
            count.Location = new Point(67, 71);
            count.Name = "count";
            count.Size = new Size(195, 23);
            count.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 74);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 12;
            label1.Text = "Кол-во:";
            label1.Click += label1_Click;
            // 
            // materialsList
            // 
            materialsList.Location = new Point(12, 100);
            materialsList.Multiline = true;
            materialsList.Name = "materialsList";
            materialsList.Size = new Size(250, 92);
            materialsList.TabIndex = 13;
            materialsList.TextChanged += materialsList_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(100, 15);
            label2.TabIndex = 14;
            label2.Text = "Укажите продукт";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 53);
            label3.Name = "label3";
            label3.Size = new Size(166, 15);
            label3.TabIndex = 15;
            label3.Text = "Укажите кличество продукта";
            // 
            // CalculationsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 232, 211);
            ClientSize = new Size(274, 230);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(materialsList);
            Controls.Add(label1);
            Controls.Add(count);
            Controls.Add(calcBtn);
            Controls.Add(material);
            Controls.Add(back);
            Name = "CalculationsForm";
            Text = "CalculationsForm";
            Load += CalculationsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button back;
        private ComboBox material;
        private Button calcBtn;
        private TextBox count;
        private Label label1;
        private TextBox materialsList;
        private Label label2;
        private Label label3;
    }
}