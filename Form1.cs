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
            sady_combo.SelectedIndex = 0;
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
                form1_listview.AddManyColumns(false,"Ulica", "Dzielnica", "Osiedle", "parzyste", "nieparzyste");
            }
            if (!rsltat.Any()) label_for_notfound.Show();
            else label_for_notfound.Hide();
            foreach(var p in rsltat)
            {
                form1_listview.Items.Add(new ListViewItem(p.GetRowFromNode("nazwa_ulicy", "dzielnica", "osiedle", "parzyste", "nieparzyste")));
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
            if(all_answers == null && list_of_people.SelectedIndex != 1)
            {
                MessageBox.Show("Daj no jakiś input!");
                return;
            }
            rslt.Show();
            rslt.NameLabel.Text = string.Format("Wyniki wyszukiwania {0}", list_of_people.Items[list_of_people.SelectedIndex]);
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
                    rslt.listViewOfResults.AddManyColumns(false,"Imie", "Nazwisko", "Dzielnica", "Adres", "Kod pocztowy", "Miasto");
                    foreach (string district in set)
                    {
                        var partial = from row in rslt.komornicy.baza.Elements()
                                      where (string)row.Element("dzielnica") == district
                                      select row;
                        foreach (XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.
                                Add(new ListViewItem(x.GetRowFromNode("imie", "nazwisko", "dzielnica", "adres", "kodpocztowy", "miasto")));
                        }
                    }
                    break;
                case 1: // SADY, nieczułe na ulicę
                    var res = from row in rslt.sady.baza.Elements()
                              where (string)row.Element("rodzajsprawy") == (string)sady_combo.Items[sady_combo.SelectedIndex]
                              select row;
                    rslt.listViewOfResults.AddManyColumns(true,"Instytucja", "Wydział", "Adres", "Kod pocztowy", "Miasto", "Objaśnienie");
                    foreach (XElement x in res)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "wydzial", "ulica", "kodpocztowy", "miasto", "objasnienie")));
                    }
                    break;
                case 2: // PROKURATURY
                    foreach (XElement data in all_answers)
                    {
                        KeyValuePair<string, string> t = 
                            new KeyValuePair<string, string>((string)data.Element("dzielnica"), (string)data.Element("extend"));
                        set.Add(t);
                    }
                    if (CBoxSpecial.Checked) set.Add(new KeyValuePair<string, string>("None", "None"));
                    rslt.listViewOfResults.AddManyColumns(false,"Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    foreach (KeyValuePair<string, string> district in set)
                    {
                        var partial = from row in rslt.prokuratura.baza.Elements()
                                      where ((string)row.Element("dzielnica") == district.Key 
                                            && (string)row.Element("extend") == district.Value) 
                                      select row;
                        foreach (XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.
                                Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy",  "telefon1" , "telefon2")));
                        }
                    }
                    break;
                case 3:
                    foreach (XElement data in all_answers)
                    {
                        KeyValuePair<string, string> t =
                            new KeyValuePair<string, string>((string)data.Element("dzielnica"), (string)data.Element("extend"));
                        set.Add(t);
                    }
                    if (CBoxSpecial.Checked) set.Add(new KeyValuePair<string, string>("None", "None"));
                    rslt.listViewOfResults.AddManyColumns(false,"Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    foreach (KeyValuePair<string, string> district in set)
                    {
                        var partial = from row in rslt.policja.baza.Elements()
                                      where ((string)row.Element("dzielnica") == district.Key
                                            && (string)row.Element("extend") == district.Value)
                                      select row;
                        foreach (XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.
                                Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon1", "telefon2")));
                        }
                    }
                    break;
                case 4: // SKARBOWKA
                    foreach (XElement data in all_answers)
                    {
                        var district = (string)data.Element("dzielnica");
                        set.Add(district);
                    }
                    if (CBoxSpecial.Checked) set.Add("None");
                    rslt.listViewOfResults.AddManyColumns(false,"Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    foreach (string district in set)
                    {
                        var partial = from row in rslt.skarbowka.baza.Elements()
                                      where (string)row.Element("dzielnica") == district
                                      select row;
                        foreach (XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.
                                Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon1", "telefon2")));
                        }
                    }
                    break;
                case 5: // ZUS
                    foreach (XElement data in all_answers)
                    {
                        KeyValuePair<string, string> place = new KeyValuePair<string, string>((string)data.Element("dzielnica"), (string)data.Element("osiedle"));
                        set.Add(place);
                    }
                    rslt.listViewOfResults.AddManyColumns(false,"Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon");
                    Set rows = new Set();
                    foreach(KeyValuePair<string, string> pair in set)
                    {
                        var partial = 
                            from row in (from row in rslt.zus.baza.Elements()
                                where (string)row.Element("dzielnica") == pair.Key 
                                    && (string)row.Element("osiedle") == pair.Value
                                select row)
                            where rows.AddIfNotIn((string)row.Element("coto"))
                            select row; // no nieźle
                        foreach(XElement x in partial)
                        {
                            rslt.listViewOfResults.Items.Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon")));
                        }
                    }
                    break;
                default:
                    MessageBox.Show("pusto!");
                    break;
            }

        }
    }
}