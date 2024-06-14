using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        cards.Add(new Card("abc: fard\nbdh: cum"));
    }

}


public class Card
{
    Dictionary<string, string> data = new Dictionary<string, string>();
    public Card(string data)
    {
        Decode(data);
    }
    private Dictionary<string, string> DefaultValueSet()
    {
        return new Dictionary<string, string>()
        {
            {"Name" , "Unnamed Card"},
            {"Description" , ""},
            {"Health" , "10"},
            {"ImagePath" , ""},
        };
    }
    public void Decode(string e)
    {
        var d = RandomFunctions.Instance.StringToList(e, "\n");
        Dictionary<string, string> syus = new Dictionary<string, string>();
        foreach (string s in d)
        {
            if (s.Contains(": "))
            {
                syus.Add(s.Substring(0, s.IndexOf(": ")), s.Substring(s.IndexOf(": ") + 2));
            }
        }
        data = DefaultValueSet();
        foreach (var a in syus)
        {
            if (data.ContainsKey(a.Key))
            {
                data[a.Key] = a.Value;
            }
            else
            {
                data.Add(a.Key, a.Value);
            }
        }
    }
    public string Encode()
    {
        return RandomFunctions.Instance.DictionaryToString(data, "\n", ": ");
    }
}