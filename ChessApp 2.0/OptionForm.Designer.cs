namespace ChessApp_2._0
{
    partial class OptionForm
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
            this.DimentionSquare = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancellaButton = new System.Windows.Forms.Button();
            this.ApplicaButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DimentionSquare
            // 
            this.DimentionSquare.Location = new System.Drawing.Point(191, 9);
            this.DimentionSquare.Name = "DimentionSquare";
            this.DimentionSquare.Size = new System.Drawing.Size(100, 20);
            this.DimentionSquare.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Dimensione Quadrato scacchiera";
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(506, 273);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancellaButton
            // 
            this.CancellaButton.Location = new System.Drawing.Point(344, 273);
            this.CancellaButton.Name = "CancellaButton";
            this.CancellaButton.Size = new System.Drawing.Size(75, 23);
            this.CancellaButton.TabIndex = 5;
            this.CancellaButton.Text = "Cancella";
            this.CancellaButton.UseVisualStyleBackColor = true;
            this.CancellaButton.Click += new System.EventHandler(this.CancellaButton_Click);
            // 
            // ApplicaButton
            // 
            this.ApplicaButton.Location = new System.Drawing.Point(425, 273);
            this.ApplicaButton.Name = "ApplicaButton";
            this.ApplicaButton.Size = new System.Drawing.Size(75, 23);
            this.ApplicaButton.TabIndex = 4;
            this.ApplicaButton.Text = "Applica";
            this.ApplicaButton.UseVisualStyleBackColor = true;
            this.ApplicaButton.Click += new System.EventHandler(this.ApplicaButton_Click);
            // 
            // OptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 308);
            this.Controls.Add(this.CancellaButton);
            this.Controls.Add(this.ApplicaButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.DimentionSquare);
            this.Name = "OptionForm";
            this.Text = "Option";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox DimentionSquare;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancellaButton;
        private System.Windows.Forms.Button ApplicaButton;
    }
}