using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;
/// <summary>
/// plik zawierający wszystkie klasy zawierająca odpowiednie bazy danych
/// przy większej liczbie tychże baz obsługa tego może być dość problematyczna
/// </summary>
namespace dlakamilka
{
    public class MyBase
    {
        public XElement baza;
        public MyBase(string path)
        {
            try
            {
                baza = XElement.Load(path);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                Environment.Exit(-16);
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
