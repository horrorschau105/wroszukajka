using System;
using System.Collections.Generic;
using CustomExtensions;
/// <summary>
/// slownik przerobiony na multislownik, pozwalajacy trzymac wiele elementów o tym samym kluczu
/// nadpisane metody: Add i Get
/// </summary>
namespace dlakamilka
{
    public class MultiDictionary<TKey, TValue>  
    {
        private Dictionary<TKey, List<TValue>> _data = new Dictionary<TKey, List<TValue>>();
        public void Add(TKey k, TValue v)
        {
            if (_data.ContainsKey(k)) _data[k].Add(v);
            else _data.Add(k, new List<TValue>() { v });
        }
        public int Length
        {   get
            {
                return _data.Count;
            }
        }
        public List<TValue> get(string key)
        {
            if (key.Length < 2) return new List<TValue>();
            key = key.FirstLetterUp(); // tolerancja dla małej litery sprzodu ulicy
            string pot = "";
            int count, it;
            List<TValue> result = new List<TValue>();
            foreach (KeyValuePair<TKey, List<TValue>> pair in _data)
            {
                pot = pair.Key.ToString();
                try
                {
                    if (pot[0] != key[0]) continue;
                    count = it = 0;
                    while (it < pot.Length && it < key.Length && pot[it] == key[it])
                    {
                        count++;
                        it++;
                    }
                    if (count >= key.Length * 0.95) // ewentualne blednie wpisane ulice tez sie zmieszcza
                    {
                        foreach (TValue krotka in pair.Value)
                        {
                            result.Add(krotka);
                        }
                    }
                }
                catch (Exception)
                {
                    return result;
                }
            }
            return result;
        }
    }

}
