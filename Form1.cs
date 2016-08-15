using System;
using System.Collections.Generic;
using System.Windows.Forms;
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
        public static string komornicy(string district)
        {
            if (district == "Psie Pole") return "Fabryczna";
            if (district == "Stare Miasto") return "Śródmieście";
            return district;
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
            IEnumerable<XElement> wtf;
            rslt.label_komornicy.Hide();
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
                    rslt.listViewOfResults.AddManyColumns(false, "Imie", "Nazwisko", "Dzielnica", "Adres", "Kod pocztowy", "Miasto");
                    rslt.label_komornicy.Show();
                    wtf = (from ans in all_answers
                           join row in rslt.komornicy.baza.Elements()
                           on komornicy((string)ans.Element("dzielnica")) equals (string)row.Element("dzielnica")
                           select row)
                               .Distinct()
                               .OrderBy(row => (string)row.Element("nazwisko"));                             
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem((x.GetRowFromNode("imie", "nazwisko", "dzielnica", "adres", "kodpocztowy", "miasto"))));
                    }
                    break;
                case 1: // SADY, nieczułe na ulicę
                    rslt.listViewOfResults.AddManyColumns(true, "Instytucja", "Wydział", "Adres", "Kod pocztowy", "Miasto", "Objaśnienie");
                    wtf = (from row in rslt.sady.baza.Elements()
                           where (string)row.Element("rodzajsprawy") == (string)sady_combo.Items[sady_combo.SelectedIndex]
                           select row)
                                .OrderBy(row => (string)row.Element("coto"));
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "wydzial", "ulica", "kodpocztowy", "miasto", "objasnienie")));
                    }
                    break;
                case 2: // PROKURATURY
                    rslt.listViewOfResults.AddManyColumns(false, "Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    wtf = (from ans in all_answers
                           from t2 in rslt.prokuratura.baza.Elements().
                           Where(prok => ((string)ans.Element("dzielnica") == (string)prok.Element("dzielnica")
                           && (string)ans.Element("extend") == (string)prok.Element("extend"))
                           || (CBoxSpecial.Checked && (string)prok.Element("extend") == "None"))
                           .DefaultIfEmpty()
                           select t2)
                          .Distinct()
                          .OrderBy(row => (string)row.Element("coto"));
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon1", "telefon2")));
                    }
                    break;
                case 3:// POLICJA
                    rslt.listViewOfResults.AddManyColumns(false, "Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    wtf = (from ans in all_answers
                           from t2 in rslt.policja.baza.Elements().
                           Where(row => ((string)ans.Element("dzielnica") == (string)row.Element("dzielnica")
                           && (string)ans.Element("extend") == (string)row.Element("extend"))
                           || (CBoxSpecial.Checked && (string)row.Element("extend") == "None"))
                           .DefaultIfEmpty()
                           select t2)
                         .Distinct()
                         .OrderBy(row => (string)row.Element("coto"));
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon1", "telefon2")));
                    }
                    break;
                case 4: // SKARBOWKA
                    rslt.listViewOfResults.AddManyColumns(false, "Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon1", "Telefon2");
                    wtf = (from ans in all_answers
                           from t2 in rslt.skarbowka.baza.Elements().
                           Where(row => ((string)ans.Element("dzielnica") == (string)row.Element("dzielnica"))
                           || (CBoxSpecial.Checked && (string)row.Element("extend") == "None"))
                           .DefaultIfEmpty()
                           select t2)
                         .Distinct()
                         .OrderBy(row => (string)row.Element("coto"));
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon1", "telefon2")));
                    }
                    break;
                case 5: // ZUS
                    rslt.listViewOfResults.AddManyColumns(false,"Instytucja", "Miasto", "Adres", "Kod pocztowy", "Telefon");
                    wtf = (from ans in all_answers
                           from t2 in rslt.zus.baza.Elements().
                           Where(row => ((string)ans.Element("dzielnica") == (string)row.Element("dzielnica") && (string)ans.Element("osiedle") == (string)row.Element("osiedle"))
                           || (CBoxSpecial.Checked && (string)row.Element("extend") == "None"))
                           .DefaultIfEmpty()
                           select t2)
                         .Distinct()
                         .OrderBy(row => (string)row.Element("coto"));
                    foreach (XElement x in wtf)
                    {
                        rslt.listViewOfResults.Items.
                            Add(new ListViewItem(x.GetRowFromNode("coto", "miasto", "ulica", "kodpocztowy", "telefon")));
                    }
                    break;
                default:
                    MessageBox.Show("pusto!");
                    break;
            }

        }
    }
}