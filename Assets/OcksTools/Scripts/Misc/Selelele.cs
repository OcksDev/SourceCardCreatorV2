using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Selelele : MonoBehaviour
{
    public TextMeshProUGUI text;
    public string FilePath;
    public void Start()
    {
        int i = FilePath.LastIndexOf("/");
        if(i == -1) i = FilePath.LastIndexOf("\\");

        var e = FilePath.Substring(i+1);
        i = e.LastIndexOf(".");
        e = e.Substring(0,i);
        text.text = e;
    }

    public void PickMe()
    {
        Gamer.Instance.LoadCardFromPath(FilePath);
    }

}
