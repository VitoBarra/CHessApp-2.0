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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Start_button = new System.Windows.Forms.Button();
            this.Reset_button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.GameMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.PlayerVsPlayerGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayerVsAIGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayWhitWhiteGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.PlayWhitBlackGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.AiVsAiGameMode = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolStripDropDownButton();
            this.SetPositionTool = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.SystemColors.Menu;
            this.Start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_button.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.Location = new System.Drawing.Point(119, 28);
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
            this.Reset_button.Location = new System.Drawing.Point(200, 28);
            this.Reset_button.Name = "Reset_button";
            this.Reset_button.Size = new System.Drawing.Size(75, 23);
            this.Reset_button.TabIndex = 1;
            this.Reset_button.Text = "Reset";
            this.Reset_button.UseVisualStyleBackColor = false;
            this.Reset_button.Click += new System.EventHandler(this.Reset_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GameMode,
            this.Tool});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(399, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // GameMode
            // 
            this.GameMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.GameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayerVsPlayerGameMode,
            this.PlayerVsAIGameMode,
            this.AiVsAiGameMode});
            this.GameMode.Image = ((System.Drawing.Image)(resources.GetObject("GameMode.Image")));
            this.GameMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GameMode.Name = "GameMode";
            this.GameMode.Size = new System.Drawing.Size(82, 22);
            this.GameMode.Text = "GameMode";
            // 
            // PlayerVsPlayerGameMode
            // 
            this.PlayerVsPlayerGameMode.Name = "PlayerVsPlayerGameMode";
            this.PlayerVsPlayerGameMode.Size = new System.Drawing.Size(180, 22);
            this.PlayerVsPlayerGameMode.Text = "Player vs Player";
            this.PlayerVsPlayerGameMode.Click += new System.EventHandler(this.PlayerVsPlayerGameMode_Click);
            // 
            // PlayerVsAIGameMode
            // 
            this.PlayerVsAIGameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayWhitWhiteGameMode,
            this.PlayWhitBlackGameMode});
            this.PlayerVsAIGameMode.Name = "PlayerVsAIGameMode";
            this.PlayerVsAIGameMode.Size = new System.Drawing.Size(180, 22);
            this.PlayerVsAIGameMode.Text = "Player Vs AI";
            // 
            // PlayWhitWhiteGameMode
            // 
            this.PlayWhitWhiteGameMode.Name = "PlayWhitWhiteGameMode";
            this.PlayWhitWhiteGameMode.Size = new System.Drawing.Size(180, 22);
            this.PlayWhitWhiteGameMode.Text = "Play whit White";
            this.PlayWhitWhiteGameMode.Click += new System.EventHandler(this.PlayWhitWhiteGameMode_Click);
            // 
            // PlayWhitBlackGameMode
            // 
            this.PlayWhitBlackGameMode.Name = "PlayWhitBlackGameMode";
            this.PlayWhitBlackGameMode.Size = new System.Drawing.Size(180, 22);
            this.PlayWhitBlackGameMode.Text = "Play whit Black";
            this.PlayWhitBlackGameMode.Click += new System.EventHandler(this.PlayWhitBlackGameMode_Click);
            // 
            // AiVsAiGameMode
            // 
            this.AiVsAiGameMode.Name = "AiVsAiGameMode";
            this.AiVsAiGameMode.Size = new System.Drawing.Size(180, 22);
            this.AiVsAiGameMode.Text = "Ai Vs Ai";
            this.AiVsAiGameMode.Click += new System.EventHandler(this.AiVsAiGameMode_Click);
            // 
            // Tool
            // 
            this.Tool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.Tool.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SetPositionTool});
            this.Tool.Image = ((System.Drawing.Image)(resources.GetObject("Tool.Image")));
            this.Tool.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Tool.Name = "Tool";
            this.Tool.Size = new System.Drawing.Size(43, 22);
            this.Tool.Text = "Tool";
            // 
            // SetPositionTool
            // 
            this.SetPositionTool.Name = "SetPositionTool";
            this.SetPositionTool.Size = new System.Drawing.Size(180, 22);
            this.SetPositionTool.Text = "Set position";
            this.SetPositionTool.Click += new System.EventHandler(this.SetPositionTool_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.Reset_button);
            this.Controls.Add(this.Start_button);
            this.Name = "Form1";
            this.Text = "ChessApp 2.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start_button;
        private System.Windows.Forms.Button Reset_button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton GameMode;
        private System.Windows.Forms.ToolStripMenuItem PlayerVsPlayerGameMode;
        private System.Windows.Forms.ToolStripMenuItem PlayerVsAIGameMode;
        private System.Windows.Forms.ToolStripMenuItem PlayWhitWhiteGameMode;
        private System.Windows.Forms.ToolStripMenuItem PlayWhitBlackGameMode;
        private System.Windows.Forms.ToolStripMenuItem AiVsAiGameMode;
        private System.Windows.Forms.ToolStripDropDownButton Tool;
        private System.Windows.Forms.ToolStripMenuItem SetPositionTool;
    }
}

