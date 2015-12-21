using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISU
{
    class SharedVariables
    {
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
