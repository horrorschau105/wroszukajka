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
        Komornicy_Wroclaw k_wr;// jeden z wyswietlanych typow
        public Results()
        {
            InitializeComponent();
            k_wr = new Komornicy_Wroclaw();
            this.Name = "Lista komorników";
            
        }
        public void ShowData(Set set) // na podstawie zbioru dzielnic ustalamy liste komornikow do pokazania
        {
            List<string> toPaste = new List<string>();
            foreach(string it in set)
            {
                toPaste.AddRange(k_wr.dbase.get(it));
            }
            foreach (string data in toPaste)
            {
                listViewOfResults.Items.Add(data);
            }
        }
    }
}
