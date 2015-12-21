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
        private delegate void NoParamDel();
        private float _playerShipDisplayX = 300;
        private float _playerShipDisplayY = 300;

        /********** Game Loop *************/
        private const int TICK_RATE = 20;
        private const int TICK_TIME = 1000 / TICK_RATE;
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
                if (timeElapsed >= TICK_TIME)
                {
                    _game.UpdateGame();
                    prevTime = curTime;
                    timeElapsed = 0;
                }
                RenderGame(timeElapsed);
            }
        }

        private void RenderGame(int elapsedTime)
        {
            float interpolation = (float)elapsedTime / (float)TICK_TIME;
            _playerShipDisplayX = _game.PlayerShip.X + interpolation * _game.PlayerShip.XVelocity;
            _playerShipDisplayY = _game.PlayerShip.Y + interpolation * (_game.PlayerShip.YVelocity + interpolation * SharedVariables.ACCEL_G / 2);
            this.Invoke(new NoParamDel(Refresh));
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
