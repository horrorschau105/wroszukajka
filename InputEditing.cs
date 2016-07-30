using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections;
namespace CustomExtensions
{
    public class Set : ArrayList
    {
        public override int Add(object toAdd)
        {
            if (!this.Contains(toAdd)) base.Add(toAdd);
            return 1;
        }
        public bool AddIfNotIn(object toAdd)
        {
            if (this.Contains(toAdd)) return false;
            this.Add(toAdd);
            return true;
        }
    }
    public static class StringExtension
    {
        public static bool IsNullOrEmpty(this string str)
        {
            if(str == null) return true;
            if(str == "") return true;
            return false;
        }
        public static string FirstLetterUp(this string str) // daje pierwsza litere wieksza, o ile na wejsciu jest faktycznie ciag znakow
        {
            if (str.IsNullOrEmpty()) return "";
            foreach (var letter in str)
            {
                if (!letter.isLetter()) return str;
            }
            string newstr="";
            if (str[0] > 96) newstr += (char)(str[0]-32); // jezeli to mala litera, to robimy uppercase
            else newstr += str[0];
            for(int i=1;i<str.Length;++i)
            {
                newstr += str[i];
            }
            return newstr;
        }
        public static bool Similar(this string pot, string key)
        {
            if (pot.IsNullOrEmpty()) return false; // no cóż...
            key = key.FirstLetterUp(); // tolerancja dla małej litery sprzodu ulicy
            int count, it;
            count = it = 0;
            while (it < pot.Length && it < key.Length && pot[it] == key[it])
            {
                count++;
                it++;
            }
            return (count >= key.Length * 0.9);
            
        }
        public static bool FindHouse(string no, string odd, string even)
        {
        if (no.IsNullOrEmpty()) return true;
        char last = no[no.Length - 1];
        if (last % 2 == 0 && even != "n") return true;
        else if (last % 2 == 1 && odd != "n") return true;
        return false;
        }
    }
    public static class CharExtension
    {
        public static bool isLetter(this char c) // Test czy char jest literą
        {
            if (64 < c && c < 92) return true;
            if (96 < c && c < 124) return true;
            return false;
        }
    }
    public static class ListViewExtension
    {
        public static void AddManyColumns(this ListView listview, bool IfLastLarge, params string[] columns)
        {
            listview.View = View.Details;
            foreach (string col in columns)
            {
                listview.Columns.Add(col, listview.Width / columns.Length, HorizontalAlignment.Center);
            }
            if (IfLastLarge) listview.Columns[listview.Columns.Count - 1].Width = listview.Width;
        }
    }
    public static class XElementExtension
    {
        public static string[] GetRowFromNode(this XElement xelement, params string[] columns)
        {
            string[] result = new string[columns.Length];
            for (int i = 0; i < columns.Length; ++i)
            {
                result[i] = (string)xelement.Element(columns[i]);
            }
            return result;
        }
    }
}
