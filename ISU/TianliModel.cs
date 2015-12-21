using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            _variables.PlayerShip.X += _variables.PlayerShip.XVelocity;
            _variables.PlayerShip.Y += _variables.PlayerShip.YVelocity + SharedVariables.ACCEL_G / 2;
            _variables.PlayerShip.YVelocity += SharedVariables.ACCEL_G;
            if (_variables.PlayerShip.X <= 0 || _variables.PlayerShip.X + 70 >= 800)
                _variables.PlayerShip.XVelocity *= -1;
            if (_variables.PlayerShip.Y <= 0)
                _variables.PlayerShip.YVelocity *= -1;
            else if (_variables.PlayerShip.Y + 90 >= 600)
                _variables.PlayerShip.YVelocity *= -1;
        }
    }
}
