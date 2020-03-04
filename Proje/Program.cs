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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow(800,600));   //Draw 800*600 form
        }
    }
}
