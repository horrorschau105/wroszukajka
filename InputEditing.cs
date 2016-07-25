using System;
/// <summary>
/// klasa zawierająca metodę rozszerzającą klasę standardową string i char
/// </summary>
namespace CustomExtensions
{
    public static class StringExtension
    {
        public static string FirstLetterUp(this String str) // daje pierwsza litere wieksza, o ile na wejsciu jest faktycznie ciag znakow
        {
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
        public static bool Similar(this String pot, string key)
        {
            int count, it;
            count = it = 0;
            while (it < pot.Length && it < key.Length && pot[it] == key[it])
            {
                count++;
                it++;
            }
            return (count >= key.Length * 0.7);
            
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
}
