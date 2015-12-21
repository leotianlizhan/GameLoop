using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISU
{
    public partial class GameForm : Form
    {
        /********** Game Loop *************/
        private const int FPS = 60;
        private const int FRAME_TIME = 1000 / 60;
        private Thread _gameThread;
        private delegate void Del();
        /********** Game Loop *************/

        /********** Game Data *************/
        private GameModelWrapper _game = new GameModelWrapper();
        /********** Game Data *************/

        /// <summary>
        /// Creates the form for the game
        /// </summary>
        public GameForm()
        {
            InitializeComponent();
            _gameThread = new Thread(GameMain);
            _gameThread.IsBackground = true;
            _gameThread.Start();
        }

        /// <summary>
        /// Main loop for the game
        /// </summary>
        private void GameMain()
        {
            //stores the current, previous, and elapsed time
            int curTime;
            int prevTime = Environment.TickCount;
            int timeElapsed;
            Del RefreshDelegate = new Del(Refresh);

            //infinity loop for the game until the game ends
            while (true)
            {
                //calculates current and elapsed time
                curTime = Environment.TickCount;
                timeElapsed = curTime - prevTime;
                //check if the elapsed time is greater or equal to the time we need to update
                if (timeElapsed >= FRAME_TIME)
                {
                    _game.UpdateGame();
                    this.Invoke(RefreshDelegate);
                    prevTime = curTime;
                }
            }
        }

        private void RenderGame()
        {

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            RenderGame();
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gameThread.Abort();
            Application.Exit();
        }
    }
}
