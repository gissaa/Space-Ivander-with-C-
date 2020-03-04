/****************************************************************************
**					SAKARYA UNIVERSITY
**				    BILGISAYAR MUHENDISLIGI BOLUMU
**				    NESNEYE DAYALI PROGRAMLAMA 
**				    PROJE ODEVI
* 
**				OGRENCI ISMI.....:Gizem 
**				OGRENCI SOYISMI..:Sarıtaş
**				OGRENCI NUMARASI.:B161210383
**				DERS GRUBU…………………:D grubu
**                  
****************************************************************************/



using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proje
{
    class Alien
    {
        Image image;
        Random rnd = new Random();
        public Alien()
        {
            image = Image.FromFile("alien.png");     
            X = rnd.Next(1, 720);                   //alien start at X which is random and Y=0(outside form to inside)
            Y = 0;
        }
        public void Draw(Graphics g)
        {
            g.DrawImage(image, X, Y, 32, 32);      //Draw Image(alien)
        }
        public void Move()
        {
            Y += 1;
        }
        private int x;
        private int y;
        public int X
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
        public int Y
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
