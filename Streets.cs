using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
/// <summary>
/// plik zawierający wszystkie klasy zawierająca odpowiednie bazy danych
/// przy większej liczbie tychże baz obsługa tego może być dość problematyczna
/// </summary>
namespace dlakamilka
{
    public class Data /// klasa symulująca krotkę
    {
        public string key;
        public string value;
        public string rest;
        public Data(string u, string d, string r)
        {
            key = u;
            value = d;
            rest = r;
        }
        public string[] convert() // na tablice stringow
        {
            return new string[] { this.key, this.value, this.rest };
        }
        public override string ToString()
        {
            return key + " / " + value + " / " + rest;
        }
    }
    /* tak sie dziedziczy dx
    public class Base : Data
    {
        public Base(string u, string d, string r) : base(u, d, r)
        {

        }
    }*/
    public class Streets  // baza ulica -> dzielnica (Wrocław)
    {
        public MultiDictionary<string, Data> streetbase;
        public Streets()
        {
            streetbase = new MultiDictionary<string, Data>();
            this.readbase();
        }
        public void readbase()
        {
            try
            {
                Encoding enc = Encoding.GetEncoding("Windows-1250");
                string[] lines = File.ReadAllLines(@"database.txt", enc);
                foreach (string line in lines)
                {
                    string[] txt = line.Split(';');
                    txt[1] = txt[1].Remove(0, 1).ToString();  // wywalam taba z przodu
                    Data tmp = new Data(txt[1], txt[5], txt[0] + " / " + txt[2] + " / " + txt[3] + " / " + txt[4]);
                    streetbase.Add(txt[1], tmp);
                }
            }
            catch (Exception)
            {
                Environment.Exit(-1);
            }
        }    }
    public class Village // baza kod pocztowy -> wieś, dokładna lokalizacja
    {
        public MultiDictionary<string, Data> codesbase;
        public Village()
        {
            codesbase = new MultiDictionary<string, Data>();
            this.readbase();
        }
        public void readbase()
        {
            try
            {
                Encoding enc = Encoding.GetEncoding("Windows-1250");
                string[] lines = File.ReadAllLines(@"postcodenew.txt", enc); // 13 kolumn
                foreach (string line in lines)
                {
                    string[] txt = line.Split(';');
                    codesbase.Add(txt[0], new Data(txt[0], txt[1], txt[2] + " / " + txt[3] + " / " + txt[5] + " / " + txt[4]));
                }
            }
            catch (Exception)
            {
                Environment.Exit(-1);
            }
        }
    }
    public class Komornicy_Wroclaw // baza dzielnica -> lista komorników
    {
        public MultiDictionary<string, string> dbase;
        public Komornicy_Wroclaw()
        {
            dbase = new MultiDictionary<string, string>();
            this.readbase();
        }
        public void readbase()
        {
            try
            {
                Encoding enc = Encoding.GetEncoding("Windows-1250");
                string[] lines = File.ReadAllLines(@"komornicy-wroclaw.txt", enc); // 6 kolumn
                foreach (string line in lines)
                {
                    string[] txt = line.Split(';');
                    dbase.Add(@txt[5], (@txt[0] + " " + @txt[1] + " / " + @txt[3] + " / " + @txt[4]));
                }
            }
            catch (Exception)
            {
                Environment.Exit(-1);
            }
        }
    }
}
