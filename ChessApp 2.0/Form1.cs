using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

using Microsoft.Scripting.Hosting;

using IronPython.Modules;
using IronPython.Runtime;
using IronPython.Hosting;





namespace ChessApp_2._0
{
    public partial class Form1 : Form
    {
        Thread PyThread;
        bool clickdStart = false;
        bool clickdReset = false;
        //------------------------------------------------------In Form1----------------------------------------
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bildboard();
        }


        private void Start_Click(object sender, EventArgs e)
        {
            if (!clickdStart) 
            {
                if (!clickdStart && clickdReset)
                {
                    PyThread = new Thread(PythonIni);
                    PyThread.Start();
                    clickdReset = false;
                }
                else
                {
                    PyThread = new Thread(PythonIni);
                    PyThread.Start();
                }
                clickdStart = true;
            }

            
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            if (PyThread.IsAlive)
            {
                PyThread.Abort();
                clickdReset = true;
                clickdStart = false;
            }


            Global.boardCod = new int[8, 8]
                {{4,3,2,6,5,2,3,4 },
                 {1,1,1,1,1,1,1,1 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {-1,-1,-1,-1,-1,-1,-1,-1 },
                 {-4,-3,-2,-6,-5,-2,-3,-4 } };
            RenderPiceOnboard();
          
        }

        //------------------------------------------------------method Form1-----------------------------------

        private void Bildboard()
        {
            int offset = 0;
            int pixelPice = 50;
            Global.board = new Board[8, 8];
            Global.boardCod = new int[8, 8]
               {{4,3,2,6,5,2,3,4 },
                 {1,1,1,1,1,1,1,1 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {-1,-1,-1,-1,-1,-1,-1,-1 },
                 {-4,-3,-2,-6,-5,-2,-3,-4 } };
            //----------------------------------board AREA----------------------------------

            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    Global.board[i, j] = new Board();
                    Global.board[i, j].xPos = j;
                    Global.board[i, j].yPos = i;
                    Global.board[i, j].Parent = this;
                    Global.board[i, j].Location = new Point(j * pixelPice + offset, i * pixelPice + pixelPice);
                    Global.board[i, j].Size = new Size(pixelPice, pixelPice);

                    if (i % 2 == 0)
                    {
                        if (j % 2 == 1)
                            Global.board[i, j].BackColor = ColorTranslator.FromHtml("#744b44");
                        else
                            Global.board[i, j].BackColor = ColorTranslator.FromHtml("#f4e4b5");
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Global.board[i, j].BackColor = ColorTranslator.FromHtml("#744b44");
                        else
                            Global.board[i, j].BackColor = ColorTranslator.FromHtml("#f4e4b5");
                    }
                }

            RenderPiceOnboard();
        }
        public static void RenderPiceOnboard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    switch (Global.boardCod[i, j])
                    {
                        case 0: Global.board[i, j].BackgroundImage = null; break;
                        case 1: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\PedestrianW.png"); break;
                        case -1: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\PedestrianB.png"); break;
                        case 4: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\TowerW.png"); break;
                        case -4: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\TowerB.png"); break;
                        case 3: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\HorseW.png"); break;
                        case -3: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\HorseB.png"); break;
                        case 2: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\BishopW.png"); break;
                        case -2: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\BishopB.png"); break;
                        case 5: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\QueenW.png"); break;
                        case -5: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\QueenB.png"); break;
                        case 6: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\KingW.png"); break;
                        case -6: Global.board[i, j].BackgroundImage = System.Drawing.Image.FromFile("pice\\KingB.png"); break;
                    }

                }
        }
        private static void PythonIni()
        {
           // string pathsStr = Environment.;
            ScriptEngine engine = Python.CreateEngine();


            var paths = engine.GetSearchPaths();
            paths.Add(@"C:\\Python27\\Lib");
            paths.Add(@"c:\\python27\\lib\\site-packages\\numpy\\core");
          //  paths.Add(@"D:\\User\\Documents\\Projects\\ChessApp_2.0\\ScriptChess");
             paths.Add(@"C:\\Users\\R39\\source\\repos\\ChessApp_2.0\\ScriptChess");
            engine.SetSearchPaths(paths);

            //CompiledCode compiledCode = engine.CreateScriptSourceFromFile("D:\\User\\Documents\\Projects\\ChessApp_2.0\\ScriptChess\\ScriptChess.py").Compile();

            CompiledCode compiledCode = engine.CreateScriptSourceFromFile("C:\\Users\\R39\\source\\repos\\ChessApp_2.0\\ScriptChess\\ScriptChess.py").Compile();

            ScriptScope scope = engine.CreateScope();

            PythonPass pass = new PythonPass();
            scope.SetVariable("PythonPass", pass);


            compiledCode.Execute(scope);

        }




        #region ToolStrip item function
        private void PlayerVsPlayerGameMode_Click(object sender, EventArgs e)
        {

        }

        private void PlayWhitWhiteGameMode_Click(object sender, EventArgs e)
        {

        }

        private void PlayWhitBlackGameMode_Click(object sender, EventArgs e)
        {

        }

        private void AiVsAiGameMode_Click(object sender, EventArgs e)
        {

        }

        private void SetPositionTool_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void GameMode_Click(object sender, EventArgs e)
        {

        }
    }





    public static class Global
    {
        public static Board[,] board;
        public static int[,] boardCod;
        public static bool clicked = false;
        public static string clickStr = "";
    }

    public class PythonPass
    {
        public void BildPiceOnBoard(string pyboardSt)
        {
            int[,] num = new int[8, 8];
            for (int i = 0; i < 16; i += 2)
                for (int j = 0; j < 16; j += 2)
                {
                    string numSt = pyboardSt.Substring(i * 8 + j, 2);
                    num[i / 2, j / 2] = int.Parse(numSt);
                }
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                    Global.boardCod[i, j] = num[i, j];

            Form1.RenderPiceOnboard();
        }
        public string Mossa()
        {
            string k = Global.clickStr;
            Global.clickStr = "";
            return k;
        }
        public void CheckMate(string winner)
        {
            MessageBox.Show("CheckMate!!\nwinner " + winner);
        }
    }
}