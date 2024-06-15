using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamer : MonoBehaviour
{
    public bool[] checks = new bool[20];
    void Start()
    {
        checks[0] = true;
        UpdateMenus();
    }

    public void UpdateMenus()
    {
        Tags.refs["GeneralMenu"].SetActive(checks[0]);
        Tags.refs["ActionMenu"].SetActive(checks[1]);
        Tags.refs["GridMenu"].SetActive(checks[2]);
    }

    public void ToggleMenu(int i)
    {
        checks[i] = !checks[i];
        UpdateMenus();
    }
    public void GoToExclusive(int i)
    {
        checks[0] = false;
        checks[1] = false;
        checks[2] = false;
        checks[i] = true;
        UpdateMenus();
    }
}
