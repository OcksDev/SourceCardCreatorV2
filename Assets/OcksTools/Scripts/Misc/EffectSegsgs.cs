using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EffectSegsgs : MonoBehaviour
{
    public string key;
    public TMP_InputField name;
    public TMP_InputField color;
    public Image colordick;

    public void UpdateName()
    {
        var c = name.text;
        if (Gamer.Instance.ValidEffects.ContainsKey(c))
        {
            name.text = key;
        }
        else
        {
            Gamer.Instance.ValidEffects.Remove(key);
            key = c;
            Gamer.Instance.ValidEffects.Add(key, color.text);
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectList.txt", RandomFunctions.Instance.DictionaryToString(Gamer.Instance.ValidEffects, "\n", ": "), true);
            Carder.Instance.RenderCard();
        }
    }
    bool s = false;
    public void UpdateColor()
    {
        var c = color.text;

        s = false;
        var x = HexToColor(c);
        if (s)
        {
            color.text = "FFFFFF";
            c = color.text;
        }
        Gamer.Instance.ValidEffects[key] = c;
        FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectList.txt", RandomFunctions.Instance.DictionaryToString(Gamer.Instance.ValidEffects, "\n", ": "), true);
        UpdateDisplayCOlor();
        Carder.Instance.RenderCard();
    }

    public void Endmysuffering()
    {
        Gamer.Instance.ValidEffects.Remove(key);
        Gamer.Instance.pp.Remove(this);
        Destroy(gameObject);
        FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectList.txt", RandomFunctions.Instance.DictionaryToString(Gamer.Instance.ValidEffects, "\n", ": "), true);
        Carder.Instance.RenderCard();
    }

    public void UpdateDisplayCOlor()
    {
        colordick.color = HexToColor(color.text);
    }

    public Color32 HexToColor(string hex, string fallback = "FFFFFF")
    {
        try
        {
            hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
            byte a = 255;//assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return new Color32(r, g, b, a);
        }
        catch
        {
            s = true;
            hex = fallback;
            hex = hex.Replace("0x", "");//in case the string is formatted 0xFFFFFF
            hex = hex.Replace("#", "");//in case the string is formatted #FFFFFF
            byte a = 255;//assume fully visible unless specified in hex
            byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
            byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
            byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
            //Only use alpha if the string has enough characters
            if (hex.Length == 8)
            {
                a = byte.Parse(hex.Substring(6, 2), System.Globalization.NumberStyles.HexNumber);
            }
            return new Color32(r, g, b, a);
        }
    }
}
