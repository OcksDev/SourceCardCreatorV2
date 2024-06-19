using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Internactct : MonoBehaviour
{
    public void UpdateName()
    {
        var c = Carder.Instance;
        var e = GetComponent<TMP_InputField>().text;
        if (e == "")
        {
            c.CurrentCard.data["Name"] = "Unnamed Card";
        }
        else
        {
            c.CurrentCard.data["Name"] = e;
        }
        c.RenderCard(c.CurrentCard);
    }
    public void UpdateDesc()
    {
        var c = Carder.Instance;
        var e = GetComponent<TMP_InputField>().text;
        c.CurrentCard.data["Description"] = e;
        c.RenderCard(c.CurrentCard);
    }

    public void ApplyGrid(int i)
    {
        var c = Carder.Instance;

        List<string> strings = new List<string>();
        foreach (var item in Gamer.Instance.ParentOfSex2.GetComponentsInChildren<Cummer>())
        {
            strings.Add(item.state.ToString());
        }
        c.CurrentCard.data[$"Grid{i + 1}"] = RandomFunctions.Instance.ListToString(strings);
        c.RenderCard(c.CurrentCard);
    }
    public void CleargridOnCard(int i)
    {
        var c = Carder.Instance;
        c.CurrentCard.data[$"Grid{i + 1}"] = "";
        c.RenderCard(c.CurrentCard);
    }

    public void ClearGridOnEd()
    {
        foreach(var e in Gamer.Instance.cums)
        {
            e.state = 0;
            e.UpdateColor();
        }
    }

    public void ChangeColor(int i)
    {
        var c = Carder.Instance;
        var e = GetComponent<TMP_InputField>().text;
        switch (i)
        {
            case 0:
                c.CurrentCard.data["NameColor"] = e;
                break;
            case 1:
                c.CurrentCard.data["DescriptionColor"] = e;
                break;
            case 2:
                c.CurrentCard.data["HealthColor"] = e;
                break;
            case 3:
                c.CurrentCard.data["ImageBGColor"] = e;
                break;
            case 4:
                c.CurrentCard.data["BGColor"] = e;
                break;
            case 5:
                c.CurrentCard.data["GridBGColor"] = e;
                break;
            case 6:
                c.CurrentCard.data["GridSelfColor"] = e;
                break;
            case 7:
                c.CurrentCard.data["GridMoveColor"] = e;
                break;
            case 8:
                c.CurrentCard.data["GridInfColor"] = e;
                break;
            case 9:
                c.CurrentCard.data["GridNoneColor"] = e;
                break;
        }
        c.RenderCard(c.CurrentCard);
    }


    public void UpdateHealth()
    {
        var c = Carder.Instance;
        var e = GetComponent<TMP_InputField>().text;
        c.CurrentCard.data["Health"] = e;
        c.RenderCard(c.CurrentCard);
    }

    public void SaveCardToFile()
    {
        var e = Carder.Instance.CurrentCard.Encode();
        if(Gamer.Instance.sis != "") File.Delete(Gamer.Instance.sis);
        var ww = $"{Gamer.Instance.settings["SaveFilePath"]}/" + Carder.Instance.CurrentCard.data["Name"] + ".txt";
        FileSystem.Instance.WriteFile(ww, e, true);
        Gamer.Instance.sis = ww;
        Gamer.Instance.SendNotif($"Saved Card to \n\"{ww}\"");
        Carder.Instance.RenderCard(Carder.Instance.CurrentCard);

    }

}
