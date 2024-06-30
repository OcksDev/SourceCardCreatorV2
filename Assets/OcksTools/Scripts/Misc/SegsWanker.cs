using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SegsWanker : MonoBehaviour
{
    public TextMeshProUGUI texty;
    public int index = 0;
    public string Action = "";
    public void DeleteMe()
    {
        var card = Carder.Instance.CurrentCard;
        var l = RandomFunctions.Instance.StringToList(card.data[Action]);
        if (l.Count > 0 && l[0] == "") l.RemoveAt(0);
        l.RemoveAt(index);
        card.data[Action] = RandomFunctions.Instance.ListToString(l);
        Gamer.Instance.UpdateActionLists();
        Carder.Instance.RenderCard(card);
    }

    public void EditMe()
    {
        Gamer.Instance.EditAction(index, Action);
    }
}
