using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ISU
{
    class Ship
    {
        private float _x;
        private float _y;
        private float _velocityX = -10;
        private float _velocityY = -10;
        private float _accelY = 0;

        public Ship(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X
        {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
            }
        }
        public float Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float VelocityX
        {
            get
            {
                return _velocityX;
            }
            set
            {
                _velocityX = value;
            }
        }
        public float VelocityY
        {
            get
            {
                return _velocityY;
            }
            set
            {
                _velocityY = value;
            }
        }
        public float AccelY
        {
            get
            {
                return _accelY;
            }
            set
            {
                _accelY = value;
            }
        }
    }
}
