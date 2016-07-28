using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CustomExtensions;
using System.Linq;
using System.Xml.Linq;
namespace dlakamilka
{
    public partial class Form1 : Form
    {
        public MyBase ulice;
        public Results rslt;
        public IEnumerable<XElement> all_answers; // by miec zawsze całą listę z bazą, zamiast poszczególnych kolumn
        public Form1()
        {
            InitializeComponent();
            ulice = new MyBase("wroclaw_ulice.xml");
            thing_to_search.SelectedIndex = 0; // ustawienie poczatkowych wartosci comboboxow
            list_of_people.SelectedIndex = 0;
            label_for_notfound.Text = "Not found";
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
                form1_listview.AddManyColumns("Ulica", "Dzielnica", "Osiedle");
            }
            else if (thing_to_search.SelectedIndex == 1)
            {
                form1_listview.AddManyColumns("Kod", "Miasto", "Lokalizacja");
                // cos tu kiedys wrzucimy
             }
            if (!rsltat.Any()) label_for_notfound.Show();
            else label_for_notfound.Hide();
            foreach(var p in rsltat)
            {
                form1_listview.Items.Add(new ListViewItem(p.GetRowFromNode("nazwa_ulicy", "dzielnica", "osiedle")));
            }
            all_answers = rsltat;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            input_TextChanged(sender, null);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (list_of_people.SelectedIndex == 1)
            {
                sady_combo.Show();
                sady_combo.SelectedIndex = 0;
                Res2.Show();
            }
            else
            {
                sady_combo.Hide();
                Res2.Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            rslt = new Results();
            Set set = new Set();
            if(all_answers == null)
            {
                MessageBox.Show("Daj no jakiś input!");
                return;
            }
            rslt.Show();
            switch (list_of_people.SelectedIndex) 
            {
                case 0: // KOMORNICY
                    foreach (XElement data in all_answers)
                    {
                        // Psie pole podlega tutaj pod Fabryczną, a Stare Miasto pod Śródmieście, stąd zmiany
                        var district = (string)data.Element("dzielnica");
                        if (district == "Psie Pole") set.Add("Fabryczna");
                        else if (district == "Stare Miasto") set.Add("Śródmieście");
                        else set.Add(district);
                    }
                    rslt.listViewOfResults.AddManyColumns("Imie", "Nazwisko", "Adres", "Kod pocztowy", "Miasto");
                    foreach (string district in set)
                    {
                        var partial = from row in rslt.komornicy.baza.Elements()
                                      where (string)row.Element("dzielnica") == district
                                      select row;
                        foreach (XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.
                                Add(new ListViewItem(x.GetRowFromNode("imie", "nazwisko", "adres", "kodpocztowy", "miasto")));
                        }
                    }
                    break;
                case 2: // PROKURATURY

                    break;
                default:
                    MessageBox.Show("pusto!");
                    break;
            }

        }
    }
}