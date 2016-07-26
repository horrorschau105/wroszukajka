using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using CustomExtensions;
using System.Linq;

using System.Xml;
using System.Xml.Linq;
using System.IO;/// <summary>
/// klasa Form1 zawiera budowę Formy głównej oraz wszystkie metody obsługujące wydarzenia
/// </summary>
namespace dlakamilka
{

    public partial class Form1 : Form
    {
        public Streets streets; // pola zawierajace odpowiednie bazy danych
        public Village villages;
        public MyBase ulice, komornicy;
        public Results rslt;
        public Form1()
        {
            InitializeComponent();
            streets = new Streets();
            villages = new Village();
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
            List<Data> res = new List<Data>();
            List<Data> ex_res = new List<Data>();
            string key = main_input.Text.ToString();
            IEnumerable<XElement> rsltat = null;
            form1_listview.Clear();
            if (thing_to_search.SelectedIndex == 0)
            {
                res = streets.streetbase.get(key);

                rsltat = from row in ulice.baza.Elements()
                             where ((string)row.Element("ulica")).Similar(key) //&&
                            // StringExtension.FindHouse(house_no.Text, (string)row.Element("nieparzyste"), (string)row.Element("parzyste"))
                             select row;



                if (res.Count == 0) { label_for_notfound.Show(); label_for_notfound.Text = "Not found"; return; }
                if (house_no.Text.Length > 0) ex_res = ExtendedSearch(res, house_no.Text);
                // jesli numer jest wpisany, to mozemy zawęzić wyniki do tych, gdzie pojawia się taki numer ulicy jaki trzeba
                if (ex_res.Count > 0) res = ex_res; // jak numerem zabijemy wszystko, to lepiej zostawic to co bylo
                form1_listview.View = View.Details; // ustawiamy wlasciwy widok w listview
                form1_listview.Columns.Add("Ulica", form1_listview.Width / 6, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Osiedle", form1_listview.Width / 3, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Dzielnica", form1_listview.Width / 2, HorizontalAlignment.Center);
            }
            if (thing_to_search.SelectedIndex == 1)
            {
                if (key.Length != 6) { label_for_notfound.Show(); label_for_notfound.Text = "Wpisz kod dobrej długości i formacie (__-___)"; return; }
                res = villages.codesbase.get(key); // szukamy kodu pocztowego tylko przy pelnym kodzie, 
                // w przeciwnym wypadku pojawialo by sie za wiele odpowiedzi, rowniez tych blednych
                if (res.Count == 0) { label_for_notfound.Show(); label_for_notfound.Text = "Not found"; return; }
                form1_listview.View = View.Details;
                form1_listview.Columns.Add("Kod", form1_listview.Width / 10, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Miasto", form1_listview.Width * 3 / 10, HorizontalAlignment.Center);
                form1_listview.Columns.Add("Lokalizacja", form1_listview.Width * 6 / 10, HorizontalAlignment.Center);
            }
            label_for_notfound.Hide();
            foreach (var part in res)
            {
                form1_listview.Items.Add(new ListViewItem(part.convert())); // wrzucenie do listview wynikow
            }
            foreach(var p in rsltat)
            {
                string[] k = new string[3] { (string)p.Element("nazwa_ulicy"), (string)p.Element("dzielnica"), (string)p.Element("osiedle") };
                form1_listview.Items.Add(new ListViewItem(k));
            }
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
        /// metoda pozwalajaca odrzucic wyniki, ktore nie będą w pełni spełnić kryteriów
        /// obecnie nie do końca działa - odrzuca jedynie te rekordy, gdzie przy odpowiedniej parzystości mieszkania jest "n"
        /// </summary>
        /// <param name="list">lista wynikow wygenerowana na podstawie danej ulicy</param>
        /// <param name="nr">wpisany numer domu</param>
        /// <returns>możliwie zawężona lista z wynikami</returns>
        private static List<Data> ExtendedSearch(List<Data> list, string nr) // jak gdzies nie ma numeru w ogole, to usuwam
        {
            List<Data> ToReturn = new List<Data>();
            int HouseNo;
            try// próba parsowania nr
            {
                HouseNo = Int32.Parse(nr);
            }
            catch (Exception)
            {
                return list;
            }
            foreach (Data data in list)
            {
                string[] divide = data.rest.Split('/'); // dość ułomna próba dobrania się do nrów parzystych/nieparzystych
                for (int i = 0; i < divide.Length; ++i)
                {
                    divide[i] = divide[i].Replace("\t", " ").Replace(" ", "");
                }
                if (HouseNo % 2 == 0)
                {
                    if (divide[2] != "n") ToReturn.Add(data);
                }
                else
                {
                    if (divide[1] != "n") ToReturn.Add(data);
                }
            }
            return ToReturn;
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
                if (data.SubItems[1].Text.Remove(0, 1) == "Psie Pole") set.Add("Fabryczna");
                else if (data.SubItems[1].Text.Remove(0, 1) == "Stare Miasto") set.Add("Śródmieście");
                else set.Add(data.SubItems[1].Text.Remove(0, 1));

            }
            rslt.listViewOfResults.View = View.Details;
            rslt.listViewOfResults.Columns.Add("Dane", rslt.listViewOfResults.Width - 25, HorizontalAlignment.Center);
            rslt.ShowData(set);
        }

    }
}