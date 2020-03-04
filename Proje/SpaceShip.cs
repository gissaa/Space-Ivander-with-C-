using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje
{
    class SpaceShip
    {

        Image image;
        public SpaceShip()
        {
            Y = 430;                                   //First value of X and Y
            X = 350;                                   //X is in center of form
            image = Image.FromFile("spaceShip.png");
        }
        public void Draw(Graphics g)                   //Draw Image(spaceShip)
        {
            g.DrawImage(image, X, 490, 64, 64);
        }
        public void GoLeft()                           //SpaceShip can move left
        {
            x -= 10;
        }
        public void GoRight()                          //SpaceShip can move right
        {
            x += 10;
        }
        private int x;
        private int y;
        public int X                                   //New X value can be read and changed
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
        public int Y                                    //New Y value can be read and changed
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
