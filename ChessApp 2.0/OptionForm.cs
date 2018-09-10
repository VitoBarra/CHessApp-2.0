using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp_2._0
{
    public partial class OptionForm : Form
    {
        public OptionForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            Global.width_Height = int.Parse(DimentionSquare.Text);
            this.Close();
        }

        private void ApplicaButton_Click(object sender, EventArgs e)
        {
            Global.width_Height = int.Parse(DimentionSquare.Text);
        }

        private void CancellaButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
