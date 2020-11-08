namespace itv
{
    partial class Form1
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
            this.Holst = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Holst)).BeginInit();
            this.SuspendLayout();
            // 
            // Holst
            // 
            this.Holst.BackColor = System.Drawing.Color.White;
            this.Holst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Holst.Location = new System.Drawing.Point(0, 0);
            this.Holst.Name = "Holst";
            this.Holst.Size = new System.Drawing.Size(984, 750);
            this.Holst.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Holst.TabIndex = 0;
            this.Holst.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 750);
            this.Controls.Add(this.Holst);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Holst)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Holst;
    }
}

