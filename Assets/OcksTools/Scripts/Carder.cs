using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Carder : MonoBehaviour
{
    public List<Card> cards = new List<Card>();
    public Card CurrentCard;
    public TextMeshProUGUI title;
    public TextMeshProUGUI description;
    public TextMeshProUGUI health;
    public GameObject grid1;
    public GameObject grid2;
    public GameObject grid3;
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

    List<Image> grid1ers= new List<Image>();
    List<Image> grid2ers= new List<Image>();
    List<Image> grid3ers= new List<Image>();

    public void RenderCard(Card cum)
    {
        title.text = cum.data["Name"];


        string a1 = cum.data["Description"];


        description.text = ColorText(a1);
        health.text = cum.data["Health"];

        bool a = false;
        var b = RandomFunctions.Instance.StringToList(cum.data["Grid1"]);
        foreach (var c in b)
        {
            if (c != "" && c != "0" && c != "3")
            {
                a = true;
                break;
            }
        }
        grid1.SetActive(a);
        if (a)
        {
            if (grid1ers.Count < 1)
            {
                var w = grid1.GetComponent<Image>();
                foreach (var c in grid1.GetComponentsInChildren<Image>())
                {
                    if (c != w) grid1ers.Add(c);
                }
            }
            for (int i = 0; i < grid1ers.Count; i++)
            {
                switch (b[i])
                {
                    case "0":
                        grid1ers[i].color = Gamer.Instance.sexex[0];
                        break;
                    case "1":
                        grid1ers[i].color = Gamer.Instance.sexex[1];
                        break;
                    case "2":
                        grid1ers[i].color = Gamer.Instance.sexex[2];
                        break;
                    case "3":
                        grid1ers[i].color = Gamer.Instance.sexex[3];
                        break;
                }
            }
        }

        a = false;
        b = RandomFunctions.Instance.StringToList(cum.data["Grid2"]);
        foreach (var c in b)
        {
            if (c != "" && c != "0" && c != "3")
            {
                a = true;
                break;
            }
        }
        grid2.SetActive(a);
        if (a)
        {
            if (grid2ers.Count < 1)
            {
                var w = grid2.GetComponent<Image>();
                foreach (var c in grid2.GetComponentsInChildren<Image>())
                {
                    if (c != w) grid2ers.Add(c);
                }
            }
            for (int i = 0; i < grid2ers.Count; i++)
            {
                switch (b[i])
                {
                    case "0":
                        grid2ers[i].color = Gamer.Instance.sexex[0];
                        break;
                    case "1":
                        grid2ers[i].color = Gamer.Instance.sexex[1];
                        break;
                    case "2":
                        grid2ers[i].color = Gamer.Instance.sexex[2];
                        break;
                    case "3":
                        grid2ers[i].color = Gamer.Instance.sexex[3];
                        break;
                }
            }
        }

        a = false;
        b = RandomFunctions.Instance.StringToList(cum.data["Grid3"]);
        foreach (var c in b)
        {
            if (c != "" && c != "0" && c != "3")
            {
                a = true;
                break;
            }
        }
        grid3.SetActive(a);
        if (a)
        {
            if (grid3ers.Count < 1)
            {
                var w = grid3.GetComponent<Image>();
                foreach (var c in grid3.GetComponentsInChildren<Image>())
                {
                    if (c != w) grid3ers.Add(c);
                }
            }
            for (int i = 0; i < grid3ers.Count; i++)
            {
                switch (b[i])
                {
                    case "0":
                        grid3ers[i].color = Gamer.Instance.sexex[0];
                        break;
                    case "1":
                        grid3ers[i].color = Gamer.Instance.sexex[1];
                        break;
                    case "2":
                        grid3ers[i].color = Gamer.Instance.sexex[2];
                        break;
                    case "3":
                        grid3ers[i].color = Gamer.Instance.sexex[3];
                        break;
                }
            }
        }

    }


    public string ColorText(string e)
    {
        foreach (var ef in Gamer.Instance.ValidEffects)
        {
            var a = e.AllIndexesOf(ef.Key).ToList();
            for(int i = 0; i < a.Count; i++)
            {
                int j = (a.Count - 1) - i;
                e = e.Substring(0, a[j]) + $"<color=#{ef.Value}>" + e.Substring(a[j], ef.Key.Length) + "</color>" + e.Substring(a[j] + ef.Key.Length);
            }
        }




        return e;
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
        var em = RandomFunctions.Instance.ListToString(new List<string>(81));

        return new Dictionary<string, string>()
        {
            {"Name" , "Unnamed Card"},
            {"Description" , ""},
            {"Actions" , ""},
            {"Health" , "0"},
            {"ImagePath" , ""},
            {"Grid1" , em},
            {"Grid2" , em},
            {"Grid3" , em},
        };
    }
    public void Decode(string e)
    {
        var d = RandomFunctions.Instance.StringToList(e, "\n<> ");
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
        return RandomFunctions.Instance.DictionaryToString(data, "\n<> ", ": ");
    }
}