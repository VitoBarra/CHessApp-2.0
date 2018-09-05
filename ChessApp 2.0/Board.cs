using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChessApp_2._0
{
    public partial class Board : UserControl
    {
        public int xPos;
        public int yPos;
       
        public Board()
        {
            InitializeComponent();
        }

        private void Board_Load(object sender, EventArgs e)
        {}

        private void Board_DragEnter(object sender, DragEventArgs e)
        {

        }

        private void Board_DragDrop(object sender, DragEventArgs e)
        {

        }

        private void Board_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.boardCod[yPos, xPos] != 0 || Global.Clicked)
            {
                if (!Global.Clicked)
                {
                    Global.Clicked = true;
                    Global.clikedxPos = xPos;
                    Global.clikedyPos = yPos;
                    Global.clickStr = yPos.ToString() + xPos.ToString();
                }
                else
                {
                    Global.Clicked = false;
                    if (yPos != Global.clikedyPos || xPos != Global.clikedxPos)
                    {
                        Global.boardCod[yPos, xPos] = Global.boardCod[Global.clikedyPos, Global.clikedxPos];
                        Global.boardCod[Global.clikedyPos, Global.clikedxPos] = 0;
                        Global.clickStr = yPos.ToString() + xPos.ToString();
                    }
                    Global.clikedxPos = -1;
                    Global.clikedyPos = -1;
                }
                Form1.RenderPiceOnboard();
            }
        }
    }
}
