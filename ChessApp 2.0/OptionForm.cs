using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace ChessApp_2._0
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();

            DimentionSquareTextBox.Text = Global.Conf.AppSettings.Settings["Dimension"].Value;
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Global.width_Height = int.Parse(DimentionSquareTextBox.Text);
            Global.Conf.AppSettings.Settings["Dimension"].Value = Global.width_Height.ToString();
            Global.Conf.Save();
            this.Close();
        }

        private void ApplicaButton_Click(object sender, EventArgs e)
        {
            Global.width_Height = int.Parse(DimentionSquareTextBox.Text);
            Global.Conf.AppSettings.Settings["Dimension"].Value = Global.width_Height.ToString();
            Global.Conf.Save();
        }

        private void CancellaButton_Click(object sender, EventArgs e){ this.Close();}





        private void GameModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GameModeComboBox.SelectedIndex == 0)
                Global.Conf.AppSettings.Settings["GameMode"].Value = "\\Player_vs_Player.py";
            else if (GameModeComboBox.SelectedIndex == 1)
                Global.Conf.AppSettings.Settings["GameMode"].Value = "\\Play_With_White.py";
            else if (GameModeComboBox.SelectedIndex == 2)
                Global.Conf.AppSettings.Settings["GameMode"].Value = "\\Play_With_Black.py";
            else if (GameModeComboBox.SelectedIndex == 3)
                Global.Conf.AppSettings.Settings["GameMode"].Value = "\\Ai_vs_Ai.py";

            Global.Conf.Save(ConfigurationSaveMode.Modified);
        }

        private void DifficultyWCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DifficultyWCombo.SelectedIndex == 0)
                Global.Conf.AppSettings.Settings["DifficultyWhiteAi"].Value = "2";
            else if (DifficultyWCombo.SelectedIndex == 1)
                Global.Conf.AppSettings.Settings["DifficultyWhiteAi"].Value = "3";
            else if (DifficultyWCombo.SelectedIndex == 2)
                Global.Conf.AppSettings.Settings["DifficultyWhiteAi"].Value = "4";
            Global.Conf.Save(ConfigurationSaveMode.Modified);
        }

        private void DifficultyBcombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DifficultyBCombo.SelectedIndex == 0)
                Global.Conf.AppSettings.Settings["DifficultyBlackAi"].Value = "2";
            else if (DifficultyBCombo.SelectedIndex == 1)
                Global.Conf.AppSettings.Settings["DifficultyBlackAi"].Value = "3";
            else if (DifficultyBCombo.SelectedIndex == 2)
                Global.Conf.AppSettings.Settings["DifficultyBlackAi"].Value = "4";
            Global.Conf.Save(ConfigurationSaveMode.Modified);
        }

        private void ThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ThemeComboBox.SelectedIndex == 0)
            {
                Global.Conf.AppSettings.Settings["ThemeW"].Value = "#f4e4b5";
                Global.Conf.AppSettings.Settings["ThemeB"].Value = "#744b44";
            }
            else if (ThemeComboBox.SelectedIndex == 1)
            {
                Global.Conf.AppSettings.Settings["ThemeW"].Value = "#e6e6e6";
                Global.Conf.AppSettings.Settings["ThemeB"].Value = "#666666";
            }
            else if (ThemeComboBox.SelectedIndex == 2)
            {
                Global.Conf.AppSettings.Settings["ThemeW"].Value = "#e6e6e6";
                Global.Conf.AppSettings.Settings["ThemeB"].Value = "#00cc00";
            }
            Global.Conf.Save(ConfigurationSaveMode.Modified);


            Global.ThemeW = Global.Conf.AppSettings.Settings["ThemeW"].Value;
            Global.ThemeB = Global.Conf.AppSettings.Settings["ThemeB"].Value;

        }
    }
}
