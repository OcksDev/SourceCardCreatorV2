using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cummer : MonoBehaviour
{
    public int index = -1;
    public int state = 0;
    bool fukedass = false;
    public Image sexx;
    public Color[] sex;
    private void OnMouseEnter()
    {
        if (Input.GetMouseButton(0) && !fukedass)
        {
            NextState();
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !fukedass)
        {
            NextState();
        }
    }

    public void NextState()
    {
        state++;
        fukedass = true;
        int z = 1;
        if (index <= 8 || index >= 71) z = 2;
        List<int> p =new List<int> { 9, 18, 27, 36, 45, 54, 63, 17, 26, 35, 44, 53, 62 };
        if (p.Contains(index)) z = 2;
        if (state > z) state = 0;
        UpdateColor();
    }
    public void UpdateColor()
    {
        if (index == 40) state = 3;
        sexx.color = sex[state];
    }

    private void Update()
    {
        if (fukedass && !Input.GetMouseButton(0))
        {
            fukedass = false;
        }
    }
}
