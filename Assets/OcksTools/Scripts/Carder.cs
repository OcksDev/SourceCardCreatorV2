using System.Collections;
using System.Collections.Generic;
using System.IO;
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
        Gamer.Instance.ValidEffects = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\EffectList.txt"), "\n", ": ");
        Gamer.Instance.settings = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\Settings.txt"), "\n", ": ");
        Gamer.Instance.ValidMods = RandomFunctions.Instance.StringToList(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\EffectMods.txt"), "\n");
        
        title.text = cum.data["Name"];

        Gamer.Instance.sss.text = Gamer.Instance.sis != "" ? $"Current Open File: {Gamer.Instance.sis}" : "";

        string a1 = cum.data["Description"];
        string a2 = "";
        var b1 = RandomFunctions.Instance.StringToList(cum.data["Action1"]);
        if (b1.Count > 0 && b1[0] == "") b1.RemoveAt(0);
        if (b1.Count > 0 && b1[0] != "")
        {
            a2 += "Action 1: " + RandomFunctions.Instance.ListToString(b1) + "\n";
        }
        b1 = RandomFunctions.Instance.StringToList(cum.data["Action2"]);
        if (b1.Count > 0 && b1[0] == "") b1.RemoveAt(0);
        if (b1.Count > 0 && b1[0] != "")
        {
            a2 += "Action 2: " + RandomFunctions.Instance.ListToString(b1) + "\n";
        }
        b1 = RandomFunctions.Instance.StringToList(cum.data["Action3"]);
        if (b1.Count > 0 && b1[0] == "") b1.RemoveAt(0);
        if (b1.Count > 0 && b1[0] != "")
        {
            a2 += "Action 3: " + RandomFunctions.Instance.ListToString(b1) + "\n";
        }

        description.text = ColorText(a2 + a1);
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
        if (!(Gamer.Instance.settings["ColorText"]=="True")) return e;
        var el = e.ToLower();
        foreach (var ef in Gamer.Instance.ValidEffects)
        {
            var a = el.AllIndexesOf(ef.Key.ToLower()).ToList();
            for(int i = 0; i < a.Count; i++)
            {
                string rep = ef.Key;
                int j = (a.Count - 1) - i;
                rep = rep + FindOtherShits(el.Substring(a[j] + rep.Length));
                e = e.Substring(0, a[j]) + $"<color=#{ef.Value}>" + rep + "</color>" + e.Substring(a[j] + rep.Length);
                el = e.ToLower();
            }
        }




        return e;
    }
    public string FindOtherShits(string e)
    {
        if (e.Length == 0) return e;
        var a = e[0];
        if (e[0] == ' ') e = e.Substring(1);
        string outr = "";
        foreach(var v in Gamer.Instance.ValidMods)
        {
            var v2 = v.Replace("\r", "").ToLower();
            if (v2.Length <= e.Length && e.Substring(0, v2.Length) == v2)
            {
                var ff = $" {v.Replace("\r", "")}";
                outr += ff;
                e = e.Substring(Mathf.Clamp(ff.Length, 0, e.Length));
            }
        }
        if (e.Length > 0 && e[0] == ' ') e = e.Substring(1);
        if (e.Length > 0)
        {
            if(e.Length > 0 && (e[0] == '0' || e[0] == '1' || e[0] == '2' || e[0] == '3' || e[0] == '4' || e[0] == '5' || e[0] == '6' || e[0] == '7' || e[0] == '8' || e[0] == '9' || e[0] == '-'))
                outr += " ";
            while (e.Length > 0 &&( e[0] == '0'|| e[0] == '1' || e[0] == '2' || e[0] == '3' || e[0] == '4' || e[0] == '5' || e[0] == '6' || e[0] == '7' || e[0] == '8' || e[0] == '9'  || e[0] == '-'))
            {
                outr += e[0];
                e = e.Substring(1);
            }
        }

        return outr;
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
            {"Health" , "0"},
            {"ImagePath" , ""},
            {"Action1" , ""},
            {"Action2" , ""},
            {"Action3" , ""},
            {"Grid1" , em},
            {"Grid2" , em},
            {"Grid3" , em},
        };
    }
    public void Decode(string e)
    {
        bool cum = true;
        if(e.Length >= 5)
        {
            switch (e.Substring(0, 5))
            {
                case "SONST":
                    cum = false;
                    data = DefaultValueSet();
                    var e2 = RandomFunctions.Instance.StringToList(e, "\n{|}");
                    e2.RemoveAt(0);
                    e2.RemoveAt(0);
                    var a = RandomFunctions.Instance.StringToList(e2[0].Substring(e2[0].IndexOf(": ") + 2), "^%^");
                    data["Name"] = a[0];
                    data["ImagePath"] = a[1];
                    data["Health"] = a[2];
                    data["Description"] = a[3];

                    var w = RandomFunctions.Instance.StringToList(e2[3].Substring(e2[3].IndexOf(": ") + 2), "^%^");
                    for (int i = 0; i < w.Count; i++)
                    {
                        if (w[i] == "3") w[i] = "1";
                    }
                    w[40] = "3";
                    w.Reverse();
                    w.RemoveAt(0);
                    data["Grid1"] = RandomFunctions.Instance.ListToString(w);
                    w = RandomFunctions.Instance.StringToList(e2[6].Substring(e2[6].IndexOf(": ") + 2), "^%^");
                    for (int i = 0; i < w.Count; i++)
                    {
                        if (w[i] == "3") w[i] = "1";
                    }
                    w[40] = "3";
                    w.Reverse();
                    w.RemoveAt(0);
                    data["Grid2"] = RandomFunctions.Instance.ListToString(w);
                    w = RandomFunctions.Instance.StringToList(e2[9].Substring(e2[9].IndexOf(": ") + 2), "^%^");
                    for (int i = 0; i < w.Count; i++)
                    {
                        if (w[i] == "3") w[i] = "1";
                    }
                    w[40] = "3";
                    w.Reverse();
                    w.RemoveAt(0);
                    data["Grid3"] = RandomFunctions.Instance.ListToString(w);

                    var wi = RandomFunctions.Instance.StringToDictionary("Attack/ff0200\r\nAttack [F]/ff0200\r\nAttack [A]/ff0200\r\nAttack [R]/ff0200\r\nMove/002aff\r\nPoison/990000\r\nPoison [F]/990000\r\nPoison [A]/990000\r\nPoison [R]/990000\r\nArmor/79c073\r\nArmor [O]/79c073\r\nArmor [A]/79c073\r\nHeal/0dad00\r\nHeal [O]/0dad00\r\nHeal [A]/0dad00\r\nExhaustion/ffff00\r\nExhaustion [F]/ffff00\r\nExhaustion [A]/ffff00\r\nExhaustion [O]/ffff00\r\nRitual/cfcf6a\r\nSwift/adad23\r\nLimit/c97833\r\nArc/b900ff\r\nGuide/4d5893\r\nVault/213598\r\nBeheading/a80402\r\nKnockback/c55958\r\nSnipe/9a4b4b\r\nStopper/5f0ce2\r\nAide/ff9900\r\nGrenade/e86100\r\nArena/ffaa00\r\n", "\r\n", "/");

                    var w1 = RandomFunctions.Instance.StringToList(e2[1].Substring(e2[1].IndexOf(": ") + 2), "^%^");
                    var w2 = RandomFunctions.Instance.StringToList(e2[2].Substring(e2[2].IndexOf(": ") + 2), "^%^");
                    List<string> shi = new List<string>();
                    for (int i = 0; i < w1.Count; i++)
                    {
                        if (w1[i] == "True")
                        {
                            string comp = wi.ElementAt(i).Key;
                            if (w2[i] != "") comp += " " + w2[i];
                            shi.Add(comp);
                        }
                    }
                    data["Action1"] = RandomFunctions.Instance.ListToString(shi);
                    w1 = RandomFunctions.Instance.StringToList(e2[4].Substring(e2[4].IndexOf(": ") + 2), "^%^");
                    w2 = RandomFunctions.Instance.StringToList(e2[5].Substring(e2[5].IndexOf(": ") + 2), "^%^");
                    shi = new List<string>();
                    for (int i = 0; i < w1.Count; i++)
                    {
                        if (w1[i] == "True")
                        {
                            string comp = wi.ElementAt(i).Key;
                            if (w2[i] != "") comp += " " + w2[i];
                            shi.Add(comp);
                        }
                    }
                    data["Action2"] = RandomFunctions.Instance.ListToString(shi);
                    w1 = RandomFunctions.Instance.StringToList(e2[7].Substring(e2[7].IndexOf(": ") + 2), "^%^");
                    w2 = RandomFunctions.Instance.StringToList(e2[8].Substring(e2[8].IndexOf(": ") + 2), "^%^");
                    shi = new List<string>();
                    for (int i = 0; i < w1.Count; i++)
                    {
                        if (w1[i] == "True")
                        {
                            string comp = wi.ElementAt(i).Key;
                            if (w2[i] != "") comp += " " + w2[i];
                            shi.Add(comp);
                        }
                    }
                    data["Action3"] = RandomFunctions.Instance.ListToString(shi);

                    break;
            }
        }
        if (cum)
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
            foreach (var ass in syus)
            {
                if (data.ContainsKey(ass.Key))
                {
                    data[ass.Key] = ass.Value;
                }
                else
                {
                    data.Add(ass.Key, ass.Value);
                }
            }
        }
    }
    public string Encode()
    {
        return "OXCRD\n<> " + RandomFunctions.Instance.DictionaryToString(data, "\n<> ", ": ");
    }
}