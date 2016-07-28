using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace dlakamilka
{
    public partial class Results : Form
    {
        public MyBase komornicy, prokuratura;
        public Results()
        {
            InitializeComponent();
            komornicy = new MyBase("wroclaw_komornicy.xml");
            prokuratura = new MyBase("wroclaw_prokuratura.xml");
        }
    }
}
