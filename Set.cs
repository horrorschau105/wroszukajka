using System.Collections;
/// <summary>
/// niegeneryczna kolekcja, zawierająca niepowtarzające się elementy i blokująca dodawanie duplikatów
/// </summary>
public class Set : ArrayList 
{
    public override int Add(object toAdd)
    {
        if (!this.Contains(toAdd)) base.Add(toAdd);
        return 1;
    }
}