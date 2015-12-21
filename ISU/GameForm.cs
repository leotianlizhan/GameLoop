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
        Pen tempPen = new Pen(Color.Red, 3);
        private delegate void InvalidateDel(Rectangle r);
        private delegate void Del();
        private float _playerShipDisplayX = 300;
        private float _playerShipDisplayY = 300;

        /********** Game Loop *************/
        private const int FPS = 60;
        private const int FRAME_TIME = 1000 / 60;
        private Thread _gameThread;
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
                    prevTime = curTime;
                }
                RenderGame(timeElapsed);
            }
        }

        private void RenderGame(int elapsedTime)
        {
            _playerShipDisplayX = _game.PlayerShip.X + (float)elapsedTime / (float)FRAME_TIME * _game.PlayerShip.XVelocity;
            _playerShipDisplayY = _game.PlayerShip.Y + (float)elapsedTime / (float)FRAME_TIME * _game.PlayerShip.YVelocity;
            this.Invoke(new InvalidateDel(Invalidate), new object[]{new Rectangle((int)_playerShipDisplayX, (int)_playerShipDisplayY, 50, 50)});
            this.Invoke(new Del(Update));
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.DrawRectangle(tempPen, _playerShipDisplayX, _playerShipDisplayY, 50, 50);
        }

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gameThread.Abort();
            Application.Exit();
        }
    }
}
