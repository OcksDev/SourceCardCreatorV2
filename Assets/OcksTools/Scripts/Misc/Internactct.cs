using System.Collections;
using System.Collections.Generic;
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

    public void SaveCardToFile()
    {
        var e = Carder.Instance.CurrentCard.Encode();
        FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "/" + Carder.Instance.CurrentCard.data["Name"] + ".txt", e, true);

    }

}
