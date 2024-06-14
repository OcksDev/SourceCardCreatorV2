using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Carder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public Card CurrentCard;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI health;
    public static Carder Instance;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        cards.Add(new Card(""));
        CurrentCard = cards[0];
        RenderCard(CurrentCard);
    }


    public void RenderCard(Card cum)
    {
        title.text = cum.data["Name"];
        description.text = cum.data["Description"];
        health.text = cum.data["Health"];
    }

}


public class Card
{
    public Dictionary<string, string> data = new Dictionary<string, string>();
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