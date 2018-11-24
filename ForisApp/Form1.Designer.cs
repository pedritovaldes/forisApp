namespace ForisApp
{
    partial class Form1
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
            this.procesarConfig = new System.Windows.Forms.Button();
            this.listStudents = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // procesarConfig
            // 
            this.procesarConfig.Location = new System.Drawing.Point(310, 26);
            this.procesarConfig.Name = "procesarConfig";
            this.procesarConfig.Size = new System.Drawing.Size(140, 23);
            this.procesarConfig.TabIndex = 1;
            this.procesarConfig.Text = "Procesar Config";
            this.procesarConfig.UseVisualStyleBackColor = true;
            this.procesarConfig.Click += new System.EventHandler(this.procesarConfig_Click);
            // 
            // listStudents
            // 
            this.listStudents.FormattingEnabled = true;
            this.listStudents.Location = new System.Drawing.Point(150, 126);
            this.listStudents.Name = "listStudents";
            this.listStudents.Size = new System.Drawing.Size(485, 160);
            this.listStudents.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 402);
            this.Controls.Add(this.listStudents);
            this.Controls.Add(this.procesarConfig);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button procesarConfig;
        private System.Windows.Forms.ListBox listStudents;
    }
}

