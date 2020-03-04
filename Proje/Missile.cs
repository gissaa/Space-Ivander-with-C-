using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class Missile
    {
        Image missileImage;
        public Missile()
        {
            Y = 490 - 32;                                           //Y is starting at spaceShip's Y 
            X = 400;                                                //First value of X and Y
            missileImage = Image.FromFile("missile.png");
        }
        public void DrawMissile(Graphics m)
        {
            m.DrawImage(missileImage, X, Y, 32, 32);                //Draw Image(missile)
        }
        public void Move() 
            //Missile can move up
        {
            y -= 2;
        }
        private int x;
        private int y;
        public int X                                                //New X value can be read and changed
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }
        public int Y                                                //New Y value can be read and changed
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }


    }
}
