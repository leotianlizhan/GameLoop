using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ISU
{
    class TianliModel
    {
        private GameModelWrapper _wrapper;
        private SharedVariables _variables;


        public TianliModel(GameModelWrapper wrapper, SharedVariables variables)
        {
            _wrapper = wrapper;
            _variables = variables;
        }

        public void UpdateGame()
        {
            _variables.PlayerShip.X += _variables.PlayerShip.VelocityX;
            _variables.PlayerShip.Y += _variables.PlayerShip.VelocityY + _variables.PlayerShip.AccelY / 2;
            _variables.PlayerShip.VelocityY += _variables.PlayerShip.AccelY;
            if (_variables.PlayerShip.X <= 0 || _variables.PlayerShip.X + 50 >= Screen.PrimaryScreen.Bounds.Width)
                _variables.PlayerShip.VelocityX *= -1;
            if (_variables.PlayerShip.Y + 50 >= Screen.PrimaryScreen.Bounds.Height)
            {
                _variables.PlayerShip.VelocityY = 0;
                _variables.PlayerShip.AccelY = 0;
            }
            else
                _variables.PlayerShip.AccelY = SharedVariables.ACCEL_G;
        }
    }
}
