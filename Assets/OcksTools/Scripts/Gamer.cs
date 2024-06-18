using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;
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
    public List<string> ValidMods;
    public List<Cummer> cums = new List<Cummer>();
    public List<Color32> sexex = new List<Color32>();
    public TMP_InputField evilfucker;
    public TMP_Dropdown drp1;
    public TMP_Dropdown drp2;
    public TMP_InputField drp3;
    public bool DoColorsOnText = true;
    public GameObject Action1L;
    public GameObject Action2L;
    public GameObject Action3L;
    public GameObject ActionEffect;
    public Toggle segsmyass;
    public Dictionary<string, string> settings;
    public TMP_InputField shungite;
    public TMP_InputField shungite2;
    public GameObject pt1;
    public GameObject pt2;
    public GameObject notif;
    public TextMeshProUGUI sss;
    public Toggle segsmyassdos;
    public string sis;
    float t = 0f;
    float t2 = 0f;
    bool shex = false;

    public static Gamer Instance;
    private void Awake()
    {
        Instance = this;
        ValidEffects = RandomFunctions.Instance.StringToDictionary("Attack: ff0200\r\nMove: 002aff\r\nPoison: 990000\r\nArmor: 79c073\r\nHeal: 0dad00\r\nExhaustion: ffff00\r\nRitual: cfcf6a\r\nSwift: adad23\r\nLimit: c97833\r\nArc: b900ff\r\nGuide: 4d5893\r\nVault: 213598\r\nBeheading: a80402\r\nKnockback: c55958\r\nSnipe: 9a4b4b\r\nStopper: 5f0ce2\r\nAide: ff9900\r\nGrenade: e86100\r\nArena: ffaa00", "\r\n", ": ");

        //
        ValidMods = RandomFunctions.Instance.StringToList("[O]\r\n[A]\r\n[F]\r\n[R]", "\r\n");
        if (!File.Exists(FileSystem.Instance.GameDirectory + "\\EffectList.txt"))
        {
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectList.txt", RandomFunctions.Instance.DictionaryToString(ValidEffects, "\n", ": "), true);
        }
        if (!File.Exists(FileSystem.Instance.GameDirectory + "\\EffectMods.txt"))
        {
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\EffectMods.txt", RandomFunctions.Instance.ListToString(ValidMods, "\n"), true);
        }
        settings = new Dictionary<string, string>()
        {
            {"ColorText", "True" },
            {"ImageExportPath", FileSystem.Instance.GameDirectory + "\\Images" },
            {"SaveFilePath", FileSystem.Instance.GameDirectory + "\\Saves" },
            {"Notifications", "True" },
        };
        if (!File.Exists(FileSystem.Instance.GameDirectory + "\\Settings.txt"))
        {
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\Settings.txt", RandomFunctions.Instance.DictionaryToString(settings, "\n", ": "), true);
        }

    }

    private void FixedUpdate()
    {
        if (shex)
        {
            notif.transform.position = Vector3.Lerp(pt1.transform.position, pt2.transform.position, Mathf.Sin(t * Mathf.PI));
            if (t < 0.5f)
            {
                t = Mathf.Clamp(t + Time.deltaTime, 0, 0.5f);
            }
            else
            {
                if (t2 < 2f)
                {
                    t2 = Mathf.Clamp(t2 + Time.deltaTime, 0, 2f);
                }
                else
                {
                    if (t < 1f)
                    {
                        t = Mathf.Clamp(t + Time.deltaTime, 0, 1f);
                    }
                    else
                    {
                        shex = false;
                        t = 0;
                        t2= 0;
                    }
                }
            }
        }
    }


    void Start()
    {
        checks[0] = true;
        UpdateMenus();
    }

    public void SendNotif(string e)
    {
        if (settings["Notifications"] != "True") return;
        notif.GetComponentInChildren<TextMeshProUGUI>().text = e;
        notif.transform.position = pt1.transform.position;
        shex = true;
        t = 0;
        t2 = 0;
    }

    public void NewCard()
    {
        sis = "";
        LoadCardFromText("");
    }
    public void Toggle(string type)
    {
        switch (type)
        {
            case "Color":
                settings["ColorText"] = segsmyass.isOn ? "True" : "False";
                SetSettings();
                Carder.Instance.RenderCard(Carder.Instance.CurrentCard);
                break;
            case "Notif":
                settings["Notifications"] = segsmyassdos.isOn ? "True" : "False";
                SetSettings();
                break;
        }
    }

    public void SetExportPath()
    {
        settings["ImageExportPath"] = shungite.text;
        SetSettings();
    }
    
    public void SetSavePath()
    {
        settings["SaveFilePath"] = shungite2.text;
        SetSettings();
    }

    public void ReadValidEffects()
    {
        ValidEffects = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\EffectList.txt"), "\n", ": ");
    }
    public void ReadSettings()
    {
        settings = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\Settings.txt"), "\n", ": ");
    }

    public void SetSettings()
    {
        FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\Settings.txt", RandomFunctions.Instance.DictionaryToString(settings, "\n", ": "), true);
    }

    public int applu = 0;
    public void GoToAdder(int i)
    {
        applu = i;
        checks[5] = true;
        drp1.options = new List<TMP_Dropdown.OptionData>();
        foreach (var a in ValidEffects)
        {
            var e = new TMP_Dropdown.OptionData(a.Key);
            drp1.options.Add(e);
        }
        drp2.options = new List<TMP_Dropdown.OptionData>();
        drp2.options.Add(new TMP_Dropdown.OptionData(""));
        foreach (var a in ValidMods)
        {
            var e = new TMP_Dropdown.OptionData(a);
            drp2.options.Add(e);
        }
        drp1.value = -1;
        drp2.value = -1;
        UpdateMenus();
    }


    public void UpdateMenus()
    {
        Tags.refs["GeneralMenu"].SetActive(checks[0]);
        Tags.refs["ActionMenu"].SetActive(checks[1]);
        Tags.refs["GridMenu"].SetActive(checks[2]);
        Tags.refs["ImportMenu"].SetActive(checks[3]);
        Tags.refs["SourceParseMenu"].SetActive(checks[4]);
        Tags.refs["AddEffect"].SetActive(checks[5]);
        Tags.refs["SettingsMenu"].SetActive(checks[6]);
    }

    public void ToggleMenu(int i)
    {
        checks[i] = !checks[i];
        checks[5] = false;
        if (checks[i])
        {
            switch (i)
            {
                case 3:
                    ReloadSaveFiles();
                    break;
            }
        }
        UpdateMenus();
    }

    public List<Selelele> ccum = new List<Selelele>();
    public void ReloadSaveFiles()
    {
        string[] filePaths = Directory.GetFiles(settings["SaveFilePath"], "*.txt", SearchOption.AllDirectories);
        int x = filePaths.Length - ccum.Count;
        for(int i = 0; i < x; i++)
        {
            ccum.Add(Instantiate(SexChild, transform.position, transform.rotation, ParentOfSex.transform).GetComponent<Selelele>());
        }
        for (int i = 0; i < -x; i++)
        {
            Destroy(ccum[i].gameObject);
            ccum.RemoveAt(i);
        }
        for (int i = 0; i < ccum.Count; i++)
        {
            if(ccum[i].FilePath != filePaths[i])
            {
                ccum[i].FilePath = filePaths[i];
                ccum[i].FardStart();
            }
        }
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
            else
            if (checks[5])
            {
                checks[5] = false;
                UpdateMenus();
            }
            else
            if (checks[4])
            {
                checks[4] = false;
                UpdateMenus();
            }
        }
    }

    public void GoToExclusive(int i)
    {
        checks[5] = false;
        checks[0] = false;
        checks[1] = false;
        checks[2] = false;
        checks[6] = false;
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
            case 1:
                UpdateActionLists();
                break;
            case 6:
                ReadSettings();
                segsmyass.isOn = settings["ColorText"]=="True";
                shungite.text = settings["ImageExportPath"];
                shungite2.text = settings["SaveFilePath"];
                segsmyassdos.isOn = settings["Notifications"] == "True";
                break;
        }

        UpdateMenus();
    }

    public void UpdateActionLists()
    {
        foreach (var a in Action1L.GetComponentsInChildren<SegsWanker>())
        {
            Destroy(a.gameObject);
        }
        foreach (var a in Action2L.GetComponentsInChildren<SegsWanker>())
        {
            Destroy(a.gameObject);
        }
        foreach (var a in Action3L.GetComponentsInChildren<SegsWanker>())
        {
            Destroy(a.gameObject);
        }
        var card = Carder.Instance.CurrentCard;
        var l = RandomFunctions.Instance.StringToList(card.data["Action1"]);
        if (l.Count > 0 && l[0] == "") l.RemoveAt(0);
        for (int i = 0; i < l.Count; i++)
        {
            var e = Instantiate(ActionEffect, transform.position, transform.rotation, Action1L.transform).GetComponent<SegsWanker>();
            e.texty.text = l[i];
            e.index = i;
            e.Action = "Action1";
        }
        l = RandomFunctions.Instance.StringToList(card.data["Action2"]);
        if (l.Count > 0 && l[0] == "") l.RemoveAt(0);
        for (int i = 0; i < l.Count; i++)
        {
            var e = Instantiate(ActionEffect, transform.position, transform.rotation, Action2L.transform).GetComponent<SegsWanker>();
            e.texty.text = l[i];
            e.index = i;
            e.Action = "Action2";
        }l = RandomFunctions.Instance.StringToList(card.data["Action3"]);
        if (l.Count > 0 && l[0] == "") l.RemoveAt(0);
        for(int i = 0; i < l.Count; i++)
        {
            var e = Instantiate(ActionEffect, transform.position, transform.rotation, Action3L.transform).GetComponent<SegsWanker>();
            e.texty.text = l[i];
            e.index = i;
            e.Action = "Action3";
        }
    }

    public void AddCardEffect()
    {
        var e = ValidEffects.ElementAt(drp1.value).Key;
        e = e + (drp2.value > 0 ? ($" {ValidMods[drp2.value-1]}") : "");
        var e2 = drp3.text;
        if(e2 != "" && e2 != "0")
        {
            e += " " + e2;
        }
        var cd = Carder.Instance.CurrentCard;
        var x = RandomFunctions.Instance.StringToList( cd.data[$"Action{applu+1}"]);
        x.Add(e);
        cd.data[$"Action{applu + 1}"] = RandomFunctions.Instance.ListToString(x);
        drp3.text = "";
        Carder.Instance.RenderCard(cd);
        checks[5] = false;
        UpdateActionLists();
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
        var e = File.ReadAllText(path);
        sis = path;
        SendNotif($"Loaded card from file\n\"{path}\"");
        LoadCardFromText(e);
    }
    public void RemoveLink()
    {
        sis = "";
        Carder.Instance.RenderCard(Carder.Instance.CurrentCard);
    }

    public void PraiseSourcesBaldCards()
    {
        var card = new Card("");
        var e = evilfucker.text;
        if (e.Substring(0,5) == "SONST")
        {
            SendNotif("Loaded card from format SONST");
            sis = "";
            LoadCardFromText(e);
        }
        else if (e.Substring(0, 5) == "OXCRD")
        {
            SendNotif("Loaded card from format OXCRD");
            sis = "";
            LoadCardFromText(e);
        }
        else
        {
            SendNotif("Attemping to parse card with unknown format");
            sis = "";
            LoadCardFromText(e);
        }
    }


    public void LoadCardFromText(string e)
    {
        checks[3] = false;
        checks[4] = false;
        checks[5] = false;
        var card = new Card(e);
        namefuiield.text = card.data["Name"];
        imagefuiield.text = card.data["ImagePath"];
        descfuiield.text = card.data["Description"];
        healthfuiield.text = card.data["Health"];
        Carder.Instance.CurrentCard = card;
        Carder.Instance.RenderCard(Carder.Instance.CurrentCard);
        GoToExclusive(0);
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
