using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/// <summary>
/// klasa odpowiadająca za wyswietlanie pelnych wynikow
/// </summary>
namespace dlakamilka
{
    public partial class Results : Form
    {
        public MyBase komornicy;
        public Results()
        {
            InitializeComponent();
            komornicy = new MyBase("wroclaw_komornicy.xml");
        }
    }
}
