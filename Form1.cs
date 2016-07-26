using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CustomExtensions;
using System.Linq;
using System.Xml.Linq;
/// <summary>
/// klasa Form1 zawiera budowę Formy głównej oraz wszystkie metody obsługujące wydarzenia
/// </summary>
namespace dlakamilka
{

    public partial class Form1 : Form
    {
        public MyBase ulice, komornicy;
        public Results rslt;
        public Form1()
        {
            InitializeComponent();
            ulice = new MyBase("wroclaw_ulice.xml");
            komornicy = new MyBase("wroclaw_komornicy.xml");
            thing_to_search.SelectedIndex = 0; // ustawienie poczatkowych wartosci comboboxow
            list_of_people.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            input_TextChanged(sender, null); 
        }
        private void input_TextChanged(object sender, EventArgs e)
        {
            string key = main_input.Text.ToString();
            IEnumerable<XElement> rsltat = null;
            form1_listview.Clear();
            if (thing_to_search.SelectedIndex == 0)
            {
                rsltat = from row in ulice.baza.Elements()
                         where ((string)row.Element("nazwa_ulicy")).Similar(key)
                         && StringExtension.FindHouse(house_no.Text, (string)row.Element("nieparzyste"), (string)row.Element("parzyste"))
                         select row;
                form1_listview.View = View.Details; // ustawiamy wlasciwy widok w listview
                form1_listview.Columns.Add("Ulica", form1_listview.Width / 6, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Osiedle", form1_listview.Width / 3, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Dzielnica", form1_listview.Width / 2, HorizontalAlignment.Center);
            }
            else if (thing_to_search.SelectedIndex == 1)
            {
                form1_listview.View = View.Details;
                form1_listview.Columns.Add("Kod", form1_listview.Width / 10, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Miasto", form1_listview.Width * 3 / 10, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Lokalizacja", form1_listview.Width * 6 / 10, HorizontalAlignment.Center);
            }
            label_for_notfound.Hide();
            foreach(var p in rsltat)
            {
                form1_listview.Items.Add(new ListViewItem(make_table(p, "nazwa_ulicy", "dzielnica", "osiedle")));
            }
        }
        private string[] make_table(XElement p,params string[] list) /// uuuuu, wo seid ihr?
        {
            string[] result = new string[list.Length];
            for(int i=0;i<list.Length;++i)
            {
                result[i] = (string)p.Element(list[i]);
            }
            return result;
        }
        /// <summary>
        /// w zaleznosci od trybu szukania pokazuję tekstbox do wpisania nru domu, lub nie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (thing_to_search.SelectedIndex == 0)
            {
                house_no.Show();
                main_input.SetBounds(main_input.Location.X, main_input.Location.Y, 190, main_input.Size.Height); // to boli
            }
            if (thing_to_search.SelectedIndex == 1)
            {
                house_no.Hide();
                main_input.SetBounds(main_input.Location.X, main_input.Location.Y, 243, main_input.Size.Height);
            }
        }
        /// <summary>
        /// również wpisanie nru domu powinno aktualizować listę wyników
        /// </summary>
        /// <param name="sender">/</param>
        /// <param name="e">/</param>
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input_TextChanged(sender, null);
        }
        /// <summary>
        /// Metoda reagująca na wybór, czego właściwie szukamy (komorników, sądów, ...) i pokazująca przycisk 
        /// umożliwiający dobranie się do wyników
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //result_button.Show();
            if (list_of_people.SelectedIndex == 1)
            {
                sady_combo.Show();
                Res2.Show();
            }
            else
            {
                sady_combo.Hide();
                Res2.Hide();
            }
            //else result_button.Hide();
        }
        /// <summary>
        /// metoda pokazująca listę komorników dla wybranych dzielnic, do których ulice z listy należą
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            rslt = new Results();
            rslt.Show();
            Set set = new Set();
            foreach (ListViewItem data in form1_listview.Items)
            {
                // Psie pole podlega tutaj pod Fabryczną, a Stare Miasto pod Śródmieście, stąd zmiany
                if (data.SubItems[1].Text == "Psie Pole") set.Add("Fabryczna");
                else if (data.SubItems[1].Text == "Stare Miasto") set.Add("Śródmieście");
                else set.Add(data.SubItems[1].Text);
            }
            rslt.listViewOfResults.View = View.Details;
            rslt.listViewOfResults.Columns.Add("Dane", rslt.listViewOfResults.Width - 25, HorizontalAlignment.Center);
            rslt.ShowData(set);
        }
    }
}