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
        public MyBase komornicy, prokuratura, skarbowka, policja, zus, sady;
        public Results()
        {
            InitializeComponent();
            komornicy = new MyBase("wroclaw_komornicy.xml");
            prokuratura = new MyBase("wroclaw_prokuratura.xml");
            skarbowka = new MyBase("wroclaw_urzadskarbowy.xml");
            policja = new MyBase("wroclaw_policja.xml");
            zus = new MyBase("wroclaw_zus.xml");
            sady = new MyBase("wroclaw_sady.xml");
        }
    }
}
