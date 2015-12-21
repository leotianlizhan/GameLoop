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
        private float _xVelocity = -10;
        private float _yVelocity = -10;

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

        public float XVelocity
        {
            get
            {
                return _xVelocity;
            }
            set
            {
                _xVelocity = value;
            }
        }
        public float YVelocity
        {
            get
            {
                return _yVelocity;
            }
            set
            {
                _yVelocity = value;
            }
        }
    }
}
