using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InSigMySexyBooty : MonoBehaviour
{
    public Image sex;
    public string path = "";

    public void FardStart()
    {
        if (Carder.Instance.CurrentCard.data["InsigniaPath"] == path)
        {
            Clickme();
        }
    }


    public void Clickme()
    {
        Carder.Instance.sexesex = sex.sprite;
        Carder.Instance.CurrentCard.data["InsigniaPath"] = path;
        Carder.Instance.RenderCard();
    }

}
