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
using System.IO;
using System.Configuration;

using Svg;
using Microsoft.Scripting.Hosting;


using IronPython.Modules;
using IronPython.Runtime;
using IronPython.Hosting;





namespace ChessApp_2._0
{
    public partial class Form1 : Form
    {
        Thread PyThread = new Thread(PythonIni);

        bool clickdStart = false;
        bool clickdReset = false;
      //  static string gameMode = "\\NUll.py";
        static string optionPathStr = FindPath() + "\\Option";
        static string pythonPath = FindPath() + "\\ScriptChess";



        //------------------------------------------------------In Form1----------------------------------------
        public Form1()
        {
            InitializeComponent();

            Global.FileReader = new StreamReader(optionPathStr + "\\Dimention.txt");
            Global.width_Height = int.Parse(Global.FileReader.ReadLine());
            Global.FileReader.Close();

            this.Width = Global.width_Height * 8 + 15;
            this.Height = Global.width_Height * 8 + Global.width_Height + 39;


            //Global.FileReader = new StreamReader(optionPathStr + "\\GameMode.txt");
            //gameMode = Global.FileReader.ReadLine();
            //Global.FileReader.Close();

        }

        public void Form1_Load(object sender, EventArgs e)
        {

            Global.SvgBitMap = LoadSvg();



            tLeft = new System.Timers.Timer() { Interval = 1000};
            tLeft.Elapsed += OnTimeEventLeft;
            LeftTimerButton.Text = leftMinutes + ":" + leftSecond;

            tRight = new System.Timers.Timer() { Interval = 1000 };
            tRight.Elapsed += OnTimeEventRight;
            RightTimerButton.Text = rightMinutes + ":" + rightSecond;


            

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
            }
            clickdReset = true;
            clickdStart = false;

            if (Global.Player)
                Global.boardCod = new int[8, 8]
                {
                 {-4,-3,-2,-6,-5,-2,-3,-4 },
                 { -1,-1,-1,-1,-1,-1,-1,-1 },
                 { 0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0 },
                 { 0,0,0,0,0,0,0,0 },
                 { 1,1,1,1,1,1,1,1 },
                 { 4,3,2,6,5,2,3,4 }
                };
            else
                Global.boardCod = new int[8, 8]
                 {
                 {4,3,2,6,5,2,3,4 },
                 {1,1,1,1,1,1,1,1 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {0,0,0,0,0,0,0,0 },
                 {-1,-1,-1,-1,-1,-1,-1,-1 },
                 {-4,-3,-2,-6,-5,-2,-3,-4 }
                 };
            RenderPiceOnboard();
          
        }

        #region -------------ToolStrip item function-------------


        private void GameModeSelector(object sender, EventArgs e)
        {
            if (sender == PlayerVsPlayerGameMode)
                ConfigurationManager.AppSettings["GameMode"] = "\\Player_vs_Player.py";
            else if (sender == PlayWhitWhiteGameMode)
                ConfigurationManager.AppSettings["GameMode"] = "\\Play_Whit_White.py";
            else if (sender == PlayWhitBlackGameMode)
                ConfigurationManager.AppSettings["GameMode"] = "\\Play_Whit_Black.py";
            else if (sender == AiVsAiGameMode)
                ConfigurationManager.AppSettings["GameMode"] = "\\Ai_vs_Ai.py";
        }
        private void DifficultyWSelector(object sender, EventArgs e)
        {
            if (sender == DificultyW2)
                ConfigurationManager.AppSettings["DifficultyWhiteAi"] = "2";
            else if (sender == DificultyW3)
                ConfigurationManager.AppSettings["DifficultyWhiteAi"] = "3";
            else if (sender == DificultyW4)
                ConfigurationManager.AppSettings["DifficultyWhiteAi"] = "4";
        }
        private void DifficultyBSelector(object sender, EventArgs e)
        {
            if (sender == DificultyB2)
                ConfigurationManager.AppSettings["DifficultyBlackAi"] = "2";
            else if (sender == DificultyB3)
                ConfigurationManager.AppSettings["DifficultyBlackAi"] = "3";
            else if (sender == DificultyB4)
                ConfigurationManager.AppSettings["DifficultyBlackAi"] = "4";
        }

        private void SetPositionTool_Click(object sender, EventArgs e)
        {

        }



        private void OptionTool_Click(object sender, EventArgs e)
        {
            OptionForm optionForm = new OptionForm { StartPosition = FormStartPosition.CenterParent };
            optionForm.ShowDialog();


            Global.FileWriter = new StreamWriter(optionPathStr + "\\Dimention.txt", false);
            Global.FileWriter.Write(Global.width_Height);
            Global.FileWriter.Close();

            Global.SvgBitMap = LoadSvg();
            Bildboard();

        }


        #endregion


        //------------------------------------------------------method Form1-----------------------------------
        #region ------------------------board-------------------
        public void Bildboard()
        {
            this.Width = Global.width_Height * 8 + 15;
            this.Height = Global.width_Height * 8 + Global.width_Height + 39;

            int offset = 0;
            int pixelPice = Global.width_Height;
            if (Global.board == null)
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
                    if (Global.board[i, j] == null)
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

        private Bitmap[] LoadSvg()
        {
            int count = 0;
            SvgDocument[] document = new SvgDocument[12];
            Bitmap[] bp = new Bitmap[12];
            string[] Files = Directory.GetFiles("pice");
            foreach(string File in Files)
            {
                document[count] = SvgDocument.Open(File);
                document[count].Width = Global.width_Height;
                document[count].Height = Global.width_Height;
                bp[count] = document[count].Draw();
                count++;
            }
            return bp;
        }

        public static void RenderPiceOnboard()
        {
            for (int i = 0; i < 8; i++)
                for (int j = 0; j < 8; j++)
                {
                    switch (Global.boardCod[i, j])
                    {
                        case 0: Global.board[i, j].BackgroundImage = null; break;
                        case 1: Global.board[i, j].BackgroundImage = Global.SvgBitMap[7]; break;
                        case -1: Global.board[i, j].BackgroundImage = Global.SvgBitMap[6]; break;
                        case 4: Global.board[i, j].BackgroundImage = Global.SvgBitMap[11]; break;
                        case -4: Global.board[i, j].BackgroundImage = Global.SvgBitMap[10]; break;
                        case 3: Global.board[i, j].BackgroundImage = Global.SvgBitMap[3]; break;
                        case -3: Global.board[i, j].BackgroundImage = Global.SvgBitMap[2]; break;
                        case 2: Global.board[i, j].BackgroundImage = Global.SvgBitMap[1]; break;
                        case -2: Global.board[i, j].BackgroundImage = Global.SvgBitMap[0]; break;
                        case 5: Global.board[i, j].BackgroundImage = Global.SvgBitMap[9]; break;
                        case -5: Global.board[i, j].BackgroundImage = Global.SvgBitMap[8]; break;
                        case 6: Global.board[i, j].BackgroundImage = Global.SvgBitMap[5]; break;
                        case -6: Global.board[i, j].BackgroundImage = Global.SvgBitMap[4]; break;
                    }

                }
        }
        private static void PythonIni()
        {
            ScriptEngine engine = Python.CreateEngine();


            var paths = engine.GetSearchPaths();
            paths.Add(@"C:\Python27\Lib");
            paths.Add(@"c:\python27\lib\site-packages\numpy\core");
            paths.Add(pythonPath);
            engine.SetSearchPaths(paths);

            CompiledCode compiledCode = engine.CreateScriptSourceFromFile(pythonPath + ConfigurationManager.AppSettings["GameMode"]).Compile();

           

            ScriptScope scope = engine.CreateScope();

            PythonPass pass = new PythonPass();
            scope.SetVariable("PythonPass", pass);


            compiledCode.Execute(scope);

        }
        public static string FindPath()
        {
            return Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).ToString()
                ).ToString()).ToString();
        }
        #endregion

        





        #region ----------------------track----------------------
        private void TrackBackButton_Click(object sender, EventArgs e)
        {
            PythonPass.Trackback = true;
        }

        private void TrackForwardButton_Click(object sender, EventArgs e)
        {

        }
        #endregion












        #region ---------------------timer--------------------

        int leftMinutes = 15, leftSecond = 00;
        int rightMinutes = 15, rightSecond = 00;

        System.Timers.Timer tLeft;
        System.Timers.Timer tRight;

        bool clickdTimerLeft = false;
        bool clickdTimerRight = false;

        private void LeftTimerButton_Click(object sender, EventArgs e)
        {
            if (!clickdTimerLeft)
            {
                tLeft.Start();
                clickdTimerLeft = true;
            }
            else
            {
                tLeft.Stop();
                clickdTimerLeft = false;
            }
        }

        private void RightTimerButton_Click(object sender, EventArgs e)
        {
            if(!clickdTimerRight)
            {
                tRight.Start();
                clickdTimerRight = true;
            }
            else
            {
                tRight.Stop();
                clickdTimerRight = false;
            }
        }


        private void OnTimeEventLeft(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (leftSecond == 0)
                {
                    if (leftMinutes >= 0)
                    {
                        leftMinutes -= 1;
                        leftSecond = 59;
                    }
                }
                else
                    leftSecond -= 1;

                LeftTimerButton.Text = leftMinutes + ":" + leftSecond;
            }
            ));
        }
        private void OnTimeEventRight(object sender, System.Timers.ElapsedEventArgs e)
        {
            Invoke(new Action(() =>
            {
                if (rightSecond == 0)
                {
                    if (rightMinutes >= 0)
                    {
                        rightMinutes -= 1;
                        rightSecond = 59;
                    }
                }
                else
                    rightSecond -= 1;


                RightTimerButton.Text = rightMinutes + ":" + rightSecond;
            }
            ));
        }
        #endregion
    }




    public static class Global
    {
        public static StreamReader FileReader;
        public static StreamWriter FileWriter;
        public static Bitmap[] SvgBitMap;
        public static int width_Height = 50;
        public static Board[,] board;
        public static int[,] boardCod;
        public static bool Player = false;
        public static bool clicked = false;
        public static string clickStr = "";
    }

    public class PythonPass
    {
        public static bool Trackback = false;



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

        #region -------------------utilitys------------------


        public bool TrackBackValue()
        {
            bool temp = Trackback;
            Trackback = false;
            return temp;
        }

        public int[] Difficulty()
        {
            int[] temp = new int[2];

            temp[0] = int.Parse(ConfigurationManager.AppSettings["DifficultyWhiteAi"]);
            temp[1] = int.Parse(ConfigurationManager.AppSettings["DifficultyBlackAi"]);

            MessageBox.Show(ConfigurationManager.AppSettings["DifficultyWhiteAi"]+" " +ConfigurationManager.AppSettings["DifficultyBlackAi"]);

            //Global.FileReader = new StreamReader(Form1.FindPath() + "\\Option\\DificultyW.txt");
            //temp[0] = Global.FileReader.Read();
            //Global.FileReader.Close();

            //Global.FileReader = new StreamReader(Form1.FindPath() + "\\Option\\DificultyB.txt");
            //temp[1] = Global.FileReader.Read();
            //Global.FileReader.Close();



            return temp;
        }

        #endregion



        #region ------------------end game-----------------
        public void CheckMate(string winner)
        {
            MessageBox.Show("CheckMate!!\nwinner " + winner);
        }
        public void DrawByRepetition()
        {
            MessageBox.Show("Pareggio per ripetizione");
        }
        public void StaleMate()
        {
            MessageBox.Show("Stallo!");
        }
        #endregion

       
    }
}