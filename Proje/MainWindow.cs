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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    class MainWindow : Form
    {
        
        SpaceShip spaceShip;
        Alien alien;
        Missile missile;
        Timer timerMissile;
        List<Missile> missiles = new List<Missile>(10);
        List<Alien> aliens = new List<Alien>();
        private int enter = 0;
        private int isPressed;

        private int countDown = 100;

        public MainWindow(int width, int height)
        {
           
            Width = width;                                //Draw form with width and height values
            Height = height;
            DoubleBuffered = true;                        
            timerMissile = new Timer();                   
            timerMissile.Interval = 1;
            timerMissile.Tick += TimerMissile_Tick;
            Paint += MainWindow_Paint;
            KeyDown += MainWindow_KeyDown;
            spaceShip = new SpaceShip();
            alien = new Alien();
            MessageBox.Show("Press Enter to Start Press Esc to Close Game");     //At start give some information about game
        }

       
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Escape)
            {
                Application.Exit();                   //When esc is pressed application close
            }
            if (e.KeyCode == Keys.Enter)
            {
                isPressed++;                          //When enter is pressed isPressed and enter values increase
                enter++;
                if (enter % 2 == 1)                   //If enter value is odd number ,timmer is starting
                { timerMissile.Start(); }
                if(enter%2==0)                         //If enter value is even number ,application is restarting
                { Application.Restart(); }
            }
            //When space is pressed and isPressed isn't first value(0) 
            //creat new missile whose X value=spaceShip's X value
            //and add to missiles' List
                if (e.KeyCode == Keys.Space && isPressed != 0)

                {
                    missile = new Missile();            
                    missile.X = spaceShip.X;
                    missiles.Add(missile);
                }
            //When left is pressed and isPressed isn't first value(0) 
            //spaceShip is moving left
            
            if (e.KeyCode == Keys.Left && isPressed != 0)
                {
                    if (spaceShip.X > 1)
                        spaceShip.GoLeft();
                    else spaceShip.X += 0;
                }

            //When right is pressed and isPressed isn't first value(0) 
            //spaceShip is moving right
            if (e.KeyCode == Keys.Right && isPressed != 0)
                {
                    if (spaceShip.X < 720)
                        spaceShip.GoRight();
                    else spaceShip.X += 0;
                }

                Invalidate();
                
            }
        
        private void TimerMissile_Tick(object sender, EventArgs e)
        {
            foreach (var item in missiles)
            {
                if (item != null)
                    item.Move();
            }
            foreach (var item in aliens)
            {
                if (item != null)
                {
                    item.Move();
                }
            }

            //for loops are control missile and alien collision 
            //missiles.Count(number) and aliens.Count(number) times
            //If they are collisioning remove this aliens and missiles
            
            for(int i=0;i<missiles.Count;i++)
            {
                for (int j = 0; j <aliens.Count; j++)
                {
                    if (missiles[i].X + 32 >= aliens[j].X 
                        && missiles[i].X <= aliens[j].X + 32 
                        && missiles[i].Y + 32 >= aliens[j].Y 
                        && missiles[i].Y <= aliens[j].Y + 32)
                    {
                        missiles.Remove(missiles[i]);
                        aliens.Remove(aliens[j]);
                        return;
                    }
                }
            }

            //If alien whose Y value is 460(spaceShip Y value) timer stop

            for(int a=0;a<aliens.Count;a++)
            {
                if (aliens[a].Y == 490-16 )
                {
                    timerMissile.Stop();
                    MessageBox.Show("Game Over Press Enter to Restart Press Esc to Close Game");
                    
                }
            }

            //If missile whose Y value is 0(outside form) this missile remove to missiles' list
            for (int b=0;b<missiles.Count;b++)
            {
                if(missiles[b].Y==0)
                {
                    missiles.Remove(missiles[b]);
                }
            }

            if (countDown == 0)
            {
                aliens.Add(new Alien());
                countDown = 100;
            }
            countDown--;
            
            Invalidate();
        }

        private void MainWindow_Paint(object sender, PaintEventArgs e)
        {


            //Draw itemMissiles and itemAliens which are in missiles' and aliens' lists
            foreach (var itemMissiles in missiles)
            {
                if (itemMissiles != null)
                    itemMissiles.DrawMissile(e.Graphics);
            }

            foreach (var itemAliens in aliens)
            {
                if (itemAliens != null)
                    itemAliens.Draw(e.Graphics);
            }

            spaceShip.Draw(e.Graphics);

        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);

        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
    }
}


