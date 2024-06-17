using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Selelele : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string FilePath;
    public void Start()
    {
        text.text = GetName();
    }
    public string GetName()
    {
        int i = FilePath.LastIndexOf("/");
        if (i < FilePath.LastIndexOf("\\")) i = FilePath.LastIndexOf("\\");

        var e = FilePath.Substring(i + 1);
        i = e.LastIndexOf(".");
        e = e.Substring(0, i);
        return e;
    }
    public void PickMe()
    {
        Gamer.Instance.LoadCardFromPath(FilePath);
    }
    public void Dupe()
    {
        var e = File.ReadAllText(FilePath);
        var c = new Card(e);
        int z = 1;
        string a = FilePath.Substring(0, FilePath.LastIndexOf("."));
        bool wen = false;
        if(a.LastIndexOf(" ") > -1)
        {
            var ww = a.Substring(a.LastIndexOf(" ") + 1);
            wen = int.TryParse(ww, out z);
        }
        if (wen)
        {
            z++;
            a = a.Substring(0, a.LastIndexOf(" "));
        }
        else
        {
            z = 1;
        }

        while (File.Exists($"{a} {z}.txt"))
        {
            z++;
        }
        c.data["Name"] = GetName() + $" {z}";
        FileSystem.Instance.WriteFile($"{a} {z}.txt", c.Encode(), true);
        Gamer.Instance.ReloadSaveFiles();
    }

    public void KillMe()
    {
        File.Delete(FilePath);
        Destroy(gameObject);
    }
}
