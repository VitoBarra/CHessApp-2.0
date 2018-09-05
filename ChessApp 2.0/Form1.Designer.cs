namespace ChessApp_2._0
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.Start_button = new System.Windows.Forms.Button();
            this.Reset_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.SystemColors.Menu;
            this.Start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_button.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.Location = new System.Drawing.Point(122, 12);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(75, 23);
            this.Start_button.TabIndex = 0;
            this.Start_button.Text = "Start";
            this.Start_button.UseVisualStyleBackColor = false;
            this.Start_button.Click += new System.EventHandler(this.Start_Click);
            // 
            // Reset_button
            // 
            this.Reset_button.BackColor = System.Drawing.SystemColors.Menu;
            this.Reset_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reset_button.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_button.Location = new System.Drawing.Point(203, 12);
            this.Reset_button.Name = "Reset_button";
            this.Reset_button.Size = new System.Drawing.Size(75, 23);
            this.Reset_button.TabIndex = 1;
            this.Reset_button.Text = "Reset";
            this.Reset_button.UseVisualStyleBackColor = false;
            this.Reset_button.Click += new System.EventHandler(this.Reset_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.Reset_button);
            this.Controls.Add(this.Start_button);
            this.Name = "Form1";
            this.Text = "ChessApp 2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Reset_button;
    }
}

