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
            this.DificultyAiWhite = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyW2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyW3 = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyW4 = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyAiBlack = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyB2 = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyB3 = new System.Windows.Forms.ToolStripMenuItem();
            this.DificultyB4 = new System.Windows.Forms.ToolStripMenuItem();
            this.Tool = new System.Windows.Forms.ToolStripDropDownButton();
            this.SetPositionTool = new System.Windows.Forms.ToolStripMenuItem();
            this.TrackBackButton = new System.Windows.Forms.Button();
            this.TrackForwardButton = new System.Windows.Forms.Button();
            this.LeftTimerButton = new System.Windows.Forms.Button();
            this.RightTimerButton = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Start_button
            // 
            this.Start_button.BackColor = System.Drawing.SystemColors.Menu;
            this.Start_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.Start_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Start_button.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Start_button.Location = new System.Drawing.Point(93, 28);
            this.Start_button.Name = "Start_button";
            this.Start_button.Size = new System.Drawing.Size(53, 23);
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
            this.Reset_button.Location = new System.Drawing.Point(152, 28);
            this.Reset_button.Name = "Reset_button";
            this.Reset_button.Size = new System.Drawing.Size(53, 23);
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
            this.PlayerVsPlayerGameMode.Size = new System.Drawing.Size(155, 22);
            this.PlayerVsPlayerGameMode.Text = "Player vs Player";
            this.PlayerVsPlayerGameMode.Click += new System.EventHandler(this.GameModeSelector);
            // 
            // PlayerVsAIGameMode
            // 
            this.PlayerVsAIGameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayWhitWhiteGameMode,
            this.PlayWhitBlackGameMode});
            this.PlayerVsAIGameMode.Name = "PlayerVsAIGameMode";
            this.PlayerVsAIGameMode.Size = new System.Drawing.Size(155, 22);
            this.PlayerVsAIGameMode.Text = "Player Vs AI";
            // 
            // PlayWhitWhiteGameMode
            // 
            this.PlayWhitWhiteGameMode.Name = "PlayWhitWhiteGameMode";
            this.PlayWhitWhiteGameMode.Size = new System.Drawing.Size(156, 22);
            this.PlayWhitWhiteGameMode.Text = "Play whit White";
            this.PlayWhitWhiteGameMode.Click += new System.EventHandler(this.GameModeSelector);
            // 
            // PlayWhitBlackGameMode
            // 
            this.PlayWhitBlackGameMode.Name = "PlayWhitBlackGameMode";
            this.PlayWhitBlackGameMode.Size = new System.Drawing.Size(156, 22);
            this.PlayWhitBlackGameMode.Text = "Play whit Black";
            this.PlayWhitBlackGameMode.Click += new System.EventHandler(this.GameModeSelector);
            // 
            // AiVsAiGameMode
            // 
            this.AiVsAiGameMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DificultyAiWhite,
            this.DificultyAiBlack});
            this.AiVsAiGameMode.Name = "AiVsAiGameMode";
            this.AiVsAiGameMode.Size = new System.Drawing.Size(155, 22);
            this.AiVsAiGameMode.Text = "Ai Vs Ai";
            this.AiVsAiGameMode.Click += new System.EventHandler(this.GameModeSelector);
            // 
            // DificultyAiWhite
            // 
            this.DificultyAiWhite.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DificultyW2,
            this.DificultyW3,
            this.DificultyW4});
            this.DificultyAiWhite.Name = "DificultyAiWhite";
            this.DificultyAiWhite.Size = new System.Drawing.Size(166, 22);
            this.DificultyAiWhite.Text = "Dificulty Ai White";
            // 
            // DificultyW2
            // 
            this.DificultyW2.Name = "DificultyW2";
            this.DificultyW2.Size = new System.Drawing.Size(80, 22);
            this.DificultyW2.Text = "2";
            this.DificultyW2.Click += new System.EventHandler(this.DifficultyWSelector);
            // 
            // DificultyW3
            // 
            this.DificultyW3.Name = "DificultyW3";
            this.DificultyW3.Size = new System.Drawing.Size(80, 22);
            this.DificultyW3.Text = "3";
            this.DificultyW3.Click += new System.EventHandler(this.DifficultyWSelector);
            // 
            // DificultyW4
            // 
            this.DificultyW4.Name = "DificultyW4";
            this.DificultyW4.Size = new System.Drawing.Size(80, 22);
            this.DificultyW4.Text = "4";
            this.DificultyW4.Click += new System.EventHandler(this.DifficultyWSelector);
            // 
            // DificultyAiBlack
            // 
            this.DificultyAiBlack.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DificultyB2,
            this.DificultyB3,
            this.DificultyB4});
            this.DificultyAiBlack.Name = "DificultyAiBlack";
            this.DificultyAiBlack.Size = new System.Drawing.Size(166, 22);
            this.DificultyAiBlack.Text = "Dificulty Ai Black";
            // 
            // DificultyB2
            // 
            this.DificultyB2.Name = "DificultyB2";
            this.DificultyB2.Size = new System.Drawing.Size(80, 22);
            this.DificultyB2.Text = "2";
            this.DificultyB2.Click += new System.EventHandler(this.DifficultyBSelector);
            // 
            // DificultyB3
            // 
            this.DificultyB3.Name = "DificultyB3";
            this.DificultyB3.Size = new System.Drawing.Size(80, 22);
            this.DificultyB3.Text = "3";
            this.DificultyB3.Click += new System.EventHandler(this.DifficultyBSelector);
            // 
            // DificultyB4
            // 
            this.DificultyB4.Name = "DificultyB4";
            this.DificultyB4.Size = new System.Drawing.Size(80, 22);
            this.DificultyB4.Text = "4";
            this.DificultyB4.Click += new System.EventHandler(this.DifficultyBSelector);
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
            this.SetPositionTool.Size = new System.Drawing.Size(136, 22);
            this.SetPositionTool.Text = "Set position";
            this.SetPositionTool.Click += new System.EventHandler(this.SetPositionTool_Click);
            // 
            // TrackBackButton
            // 
            this.TrackBackButton.BackColor = System.Drawing.SystemColors.Menu;
            this.TrackBackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrackBackButton.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackBackButton.Location = new System.Drawing.Point(12, 28);
            this.TrackBackButton.Name = "TrackBackButton";
            this.TrackBackButton.Size = new System.Drawing.Size(23, 23);
            this.TrackBackButton.TabIndex = 4;
            this.TrackBackButton.Text = "<";
            this.TrackBackButton.UseVisualStyleBackColor = false;
            this.TrackBackButton.Click += new System.EventHandler(this.TrackBackButton_Click);
            // 
            // TrackForwardButton
            // 
            this.TrackForwardButton.BackColor = System.Drawing.SystemColors.Menu;
            this.TrackForwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TrackForwardButton.Font = new System.Drawing.Font("Perpetua Titling MT", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TrackForwardButton.Location = new System.Drawing.Point(41, 28);
            this.TrackForwardButton.Name = "TrackForwardButton";
            this.TrackForwardButton.Size = new System.Drawing.Size(23, 23);
            this.TrackForwardButton.TabIndex = 5;
            this.TrackForwardButton.Text = ">";
            this.TrackForwardButton.UseVisualStyleBackColor = false;
            this.TrackForwardButton.Click += new System.EventHandler(this.TrackForwardButton_Click);
            // 
            // LeftTimerButton
            // 
            this.LeftTimerButton.Location = new System.Drawing.Point(264, 28);
            this.LeftTimerButton.Name = "LeftTimerButton";
            this.LeftTimerButton.Size = new System.Drawing.Size(48, 23);
            this.LeftTimerButton.TabIndex = 6;
            this.LeftTimerButton.Text = "00:00";
            this.LeftTimerButton.UseVisualStyleBackColor = true;
            this.LeftTimerButton.Click += new System.EventHandler(this.LeftTimerButton_Click);
            // 
            // RightTimerButton
            // 
            this.RightTimerButton.Location = new System.Drawing.Point(318, 28);
            this.RightTimerButton.Name = "RightTimerButton";
            this.RightTimerButton.Size = new System.Drawing.Size(48, 23);
            this.RightTimerButton.TabIndex = 7;
            this.RightTimerButton.Text = "00:00";
            this.RightTimerButton.UseVisualStyleBackColor = true;
            this.RightTimerButton.Click += new System.EventHandler(this.RightTimerButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(399, 450);
            this.Controls.Add(this.RightTimerButton);
            this.Controls.Add(this.LeftTimerButton);
            this.Controls.Add(this.TrackForwardButton);
            this.Controls.Add(this.TrackBackButton);
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
        private System.Windows.Forms.Button TrackBackButton;
        private System.Windows.Forms.Button TrackForwardButton;
        private System.Windows.Forms.Button LeftTimerButton;
        private System.Windows.Forms.Button RightTimerButton;
        private System.Windows.Forms.ToolStripMenuItem DificultyAiWhite;
        private System.Windows.Forms.ToolStripMenuItem DificultyW2;
        private System.Windows.Forms.ToolStripMenuItem DificultyW3;
        private System.Windows.Forms.ToolStripMenuItem DificultyW4;
        private System.Windows.Forms.ToolStripMenuItem DificultyAiBlack;
        private System.Windows.Forms.ToolStripMenuItem DificultyB2;
        private System.Windows.Forms.ToolStripMenuItem DificultyB3;
        private System.Windows.Forms.ToolStripMenuItem DificultyB4;
    }
}

