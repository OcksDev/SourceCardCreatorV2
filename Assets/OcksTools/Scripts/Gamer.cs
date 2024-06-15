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
    public TMP_InputField namefuiield;
    public TMP_InputField descfuiield;
    public TMP_InputField healthfuiield;
    public UnityEngine.UI.Image sex;
    public bool[] checks = new bool[20];
    public Sprite spsps;
    public GameObject ParentOfSex;
    public GameObject SexChild;
    public GameObject ParentOfSex2;
    public GameObject SexChild2;
    public Dictionary<string, string> ValidEffects;
    public List<Cummer> cums = new List<Cummer>();
    public List<Color32> sexex = new List<Color32>();

    public static Gamer Instance;

    void Start()
    {
        Instance = this;
        checks[0] = true;
        UpdateMenus();
        ValidEffects = RandomFunctions.Instance.StringToDictionary("Attack/ff0200\r\nAttack [F]/ff0200\r\nAttack [A]/ff0200\r\nAttack [R]/ff0200\r\nMove/002aff\r\nPoison/990000\r\nPoison [F]/990000\r\nPoison [A]/990000\r\nPoison [R]/990000\r\nArmor/79c073\r\nArmor [O]/79c073\r\nArmor [A]/79c073\r\nHeal/0dad00\r\nHeal [O]/0dad00\r\nHeal [A]/0dad00\r\nExhaustion/ffff00\r\nExhaustion [F]/ffff00\r\nExhaustion [A]/ffff00\r\nExhaustion [O]/ffff00\r\nRitual/cfcf6a\r\nSwift/adad23\r\nCommander/c97833\r\nArc/b900ff\r\nGuide/4d5893\r\nVault/213598\r\nBeheading/a80402\r\nKnockback/c55958\r\nSnipe/9a4b4b\r\nStopper/5f0ce2\r\nAide/ff9900\r\nGrenade/e86100\r\nArena/ffaa00", "\r\n", "/");
        if(!File.Exists(FileSystem.Instance.GameDirectory + "\\EffectList.txt"))
        {
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectList.txt", RandomFunctions.Instance.DictionaryToString(ValidEffects, "\n", ": "), true);
        }
    }


    public void ReadValidEffects()
    {
        ValidEffects = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\EffectList.txt"), "\n", ": ");
    }


    public void UpdateMenus()
    {
        Tags.refs["GeneralMenu"].SetActive(checks[0]);
        Tags.refs["ActionMenu"].SetActive(checks[1]);
        Tags.refs["GridMenu"].SetActive(checks[2]);
        Tags.refs["ImportMenu"].SetActive(checks[3]);
    }

    public void ToggleMenu(int i)
    {
        checks[i] = !checks[i];
        if (checks[i])
        {
            switch (i)
            {
                case 3:
                    string[] filePaths = Directory.GetFiles(FileSystem.Instance.GameDirectory + "/Saves", "*.txt", SearchOption.AllDirectories);
                    foreach(var e in ParentOfSex.GetComponentsInChildren<Selelele>())
                    {
                        Destroy(e.gameObject);
                    }
                    foreach(var s in filePaths)
                    {
                        var e = Instantiate(SexChild, transform.position, transform.rotation, ParentOfSex.transform);
                        e.GetComponent<Selelele>().FilePath = s;
                    }
                    break;
            }
        }
        UpdateMenus();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (checks[3])
            {
                checks[3] = false;
                UpdateMenus();
            }
        }
    }

    public void GoToExclusive(int i)
    {
        checks[0] = false;
        checks[1] = false;
        checks[2] = false;
        checks[i] = true;

        switch (i)
        {
            case 2:
                if(cums.Count < 4)
                {
                    for(int i2 = 0; i2 < 81; i2++)
                    {
                        var e = Instantiate(SexChild2, transform.position, transform.rotation, ParentOfSex2.transform);
                        var s = e.GetComponent<Cummer>();
                        s.index = i2;
                        cums.Add(s);
                    }
                }
                foreach(var e in cums)
                {
                    e.UpdateColor();
                }
                break;
        }

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

    public void LoadCardFromPath(string path)
    {
        Gamer.Instance.checks[3] = false;
        var e = File.ReadAllText(path);
        var card = new Card(e);
        namefuiield.text = card.data["Name"];
        imagefuiield.text = card.data["ImagePath"];
        descfuiield.text = card.data["Description"];
        healthfuiield.text = card.data["Health"];
        Carder.Instance.CurrentCard = card;
        Carder.Instance.RenderCard(Carder.Instance.CurrentCard);
        UpdateImage();
        UpdateMenus();
    }

    public void UpdateImage()
    {
        StartCoroutine(cummer());
    }
    public IEnumerator cummer()
    {
        if (FileSystem.Instance.DDH.Count < 1) FileSystem.Instance.DDH.Insert(0, new DownloadDataHandler());
        if(imagefuiield.text.Contains(".png") || imagefuiield.text.Contains(".jpg") || imagefuiield.text.Contains(".jpeg"))
        {
            Debug.Log("Valid Image");
            StartCoroutine(FileSystem.Instance.GetImage(imagefuiield.text, 0));

            yield return new WaitUntil(() => { return FileSystem.Instance.DDH[0].CompletedDownload; });
            Debug.Log("Image Found");
            if (!FileSystem.Instance.DDH[0].ErrorLol && FileSystem.Instance.DDH[0].Texture != null)
            {
                Debug.Log("Doing ur mom");
                var tex = (Texture2D)FileSystem.Instance.DDH[0].Texture;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
                sex.sprite = sprite;
                Carder.Instance.CurrentCard.data["ImagePath"] = imagefuiield.text;
            }
            else
            {
                Debug.Log("Failed doing mom");
                sex.sprite = spsps;
                Carder.Instance.CurrentCard.data["ImagePath"] = "";
            }
        }
        else
        {
            Debug.Log("Faailed valid file");
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
