using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class SharedVariables
    {
        public const float ACCEL_G = 4f;
        private Ship _playerShip = new Ship(300, 300);

        public Ship PlayerShip
        {
            get
            {
                return _playerShip;
            }
            set
            {
                _playerShip = value;
            }
        }
    }
}
