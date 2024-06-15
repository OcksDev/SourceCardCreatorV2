using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class Gamer : MonoBehaviour
{
    public TMP_InputField imagefuiield;
    public UnityEngine.UI.Image sex;
    public bool[] checks = new bool[20];
    public Sprite spsps;
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
    public void PickFile(int i)
    {
        StartCoroutine(OpenFileEELol(i));
    }
    string readout = "";

    public void SetImage(string e)
    {
        imagefuiield.text = e;
        UpdateImage();
    }

    public void UpdateImage()
    {
        StartCoroutine(cummer());
    }
    public IEnumerator cummer()
    {
        FileSystem.Instance.DDH.Add(new DownloadDataHandler());
        if(imagefuiield.text.Contains(".png") || imagefuiield.text.Contains(".jpg") || imagefuiield.text.Contains(".jpeg"))
        {
            StartCoroutine(FileSystem.Instance.GetImage(imagefuiield.text, 0));

            yield return new WaitUntil(() => { return FileSystem.Instance.DDH[0].CompletedDownload; });
            if (!FileSystem.Instance.DDH[0].ErrorLol && FileSystem.Instance.DDH[0].Texture != null)
            {
                var tex = (Texture2D)FileSystem.Instance.DDH[0].Texture;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
                sex.sprite = sprite;
                Carder.Instance.CurrentCard.data["ImagePath"] = imagefuiield.text;
            }
            else
            {
                sex.sprite = spsps;
                Carder.Instance.CurrentCard.data["ImagePath"] = "";
            }
        }
        else
        {
            sex.sprite = spsps;
            Carder.Instance.CurrentCard.data["ImagePath"] = "";
        }

    }
    public IEnumerator OpenFileEELol(int i)
    {
        Debug.Log(Directory.GetCurrentDirectory());
        yield return new WaitForEndOfFrame();
        string d = Directory.GetCurrentDirectory();
        string d2 = d;
        if (d.Contains("RarSFX0")) d2 += "\\3DOS";
        string s = d2 + "\\WinExplore";
        File.WriteAllText(d + "\\Output.txt", "");
        readout = "Waiting";
        Debug.Log(s + "\\WinExplorertesting.exe");
        System.Diagnostics.Process.Start(s + "\\WinExplorertesting.exe");
        yield return new WaitUntil(() => { try { return File.ReadAllText(d + "\\Output.txt") != ""; } catch { return false; } });



        readout = File.ReadAllText(d + "\\Output.txt");

        switch (i)
        {
            case 0:
                switch (readout)
                {
                    case "BAD":
                        SetImage("");
                        break;
                    default:
                        SetImage(readout);
                        break;
                }
                break;
        }
    }
}
