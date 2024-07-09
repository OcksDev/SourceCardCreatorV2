using System;
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
    public TMP_InputField bgfuiield;
    public TMP_InputField namefuiield;
    public TMP_InputField descfuiield;
    public TMP_InputField healthfuiield;
    public UnityEngine.UI.Image sex;
    public UnityEngine.UI.Image hotsex;
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
    public TMP_InputField searchingforshung;
    public TMP_InputField[] myballs;
    public Slider sexsexss;
    public TextMeshProUGUI sexsexsstext;
    public TextMeshProUGUI drp4;
    public TextMeshProUGUI drp5;
    public TMP_InputField rawshit;
    public Toggle segsmygigadick;
    public GameObject wankerfucker;
    public GameObject wankerfuckerchild;
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
        SetDefaultSettings();
        if (!File.Exists(FileSystem.Instance.GameDirectory + "\\Settings.txt"))
        {
            FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\Settings.txt", RandomFunctions.Instance.DictionaryToString(settings, "\n", ": "), true);
        }

    }
    public void SetDefaultSettings()
    {
        settings = new Dictionary<string, string>()
        {
            {"ColorText", "True" },
            {"ImageExportPath", FileSystem.Instance.GameDirectory + "\\Images" },
            {"SaveFilePath", FileSystem.Instance.GameDirectory + "\\Saves" },
            {"Notifications", "True" },
            {"RenderScale", "1" },
            {"LegacyEffects", "False" },
        };
    }

    public void UpdateRenderScale()
    {
        float x = sexsexss.value;
        x /= 10;
        settings["RenderScale"] = x.ToString();
        SetSettings();
        sexsexsstext.text = $"Render Scaling: {x}x";
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

        var rah = new ActionFart("Attack [F]");
        Debug.Log($"Crd: {rah.action}, {rah.mod}, {rah.amount}");
    }

    public void SetEffects()
    {
        ValidEffects = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\EffectList.txt"), "\n", ": ");
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
            case "Legacy":
                settings["LegacyEffects"] = segsmygigadick.isOn ? "True" : "False";
                SetSettings();
                Carder.Instance.RenderCard();
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
        SetDefaultSettings();
        var e = RandomFunctions.Instance.StringToDictionary(File.ReadAllText(FileSystem.Instance.GameDirectory + "\\Settings.txt"), "\n", ": ");
        foreach(var ep in e)
        {
            if (settings.ContainsKey(ep.Key))
            {
                settings[ep.Key] = ep.Value;
            }
            else
            {
                settings.Add(ep.Key, ep.Value);
            }
        }
        sexsexss.value = Mathf.RoundToInt(float.Parse(settings["RenderScale"]) * 10);
        sexsexsstext.text = $"Render Scaling: {settings["RenderScale"]}x";
    }

    public void SetSettings()
    {
        FileSystem.Instance.WriteFile(FileSystem.Instance.GameDirectory + "\\Settings.txt", RandomFunctions.Instance.DictionaryToString(settings, "\n", ": "), true);
    }

    public int applu = 0;
    public int modlu = 0;

    public void GoToAdder(int i)
    {
        GoToAdder(i, 0);
    }
    public void GoToAdder(int i, int mode = 0)
    {
        modlu = mode;
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
        drp4.text = mode == 0 ? "Add Effect" : "Edit Effect";
        drp5.text = mode == 0 ? "Add" : "Save";
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
        Tags.refs["ColorsMenu"].SetActive(checks[7]);
        Tags.refs["RawMenu"].SetActive(checks[8]);
        Tags.refs["EffectMenu"].SetActive(checks[9]);
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
                    searchingforshung.text = "";
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
            ccum[i].FilePath = filePaths[i];
            ccum[i].FardStart();
        }
        ReloadSaveSearch();
    }

    public void ReloadSaveSearch()
    {
        string e = searchingforshung.text;
        foreach (var s in ccum)
        {
            s.gameObject.SetActive(s.Nm.ToLower().Contains(e.ToLower()));
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
    public List<EffectSegsgs> pp = new List<EffectSegsgs>();
    public void GoToExclusive(int i)
    {
        checks[0] = false;
        checks[1] = false;
        checks[2] = false;
        checks[5] = false;
        checks[6] = false;
        checks[7] = false;
        checks[8] = false;
        checks[9] = false;
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
                segsmyass.isOn = settings["ColorText"] == "True";
                shungite.text = settings["ImageExportPath"];
                shungite2.text = settings["SaveFilePath"];
                segsmyassdos.isOn = settings["Notifications"] == "True";
                segsmygigadick.isOn = settings["LegacyEffects"] == "True";
                break;
            case 8:
                rawshit.text = Carder.Instance.CurrentCard.Encode();
                pshexballs.text = "";
                break;
            case 9:
                SetEffects();
                for (int iz = 0; iz < pp.Count; iz++)
                {
                    Destroy(pp[iz].gameObject);
                    pp.RemoveAt(0);
                    iz--;
                }
                for (int iz = 0; iz < ValidEffects.Count; iz++)
                {
                    var x = ValidEffects.ElementAt(iz); 
                    var e = Instantiate(wankerfuckerchild, wankerfucker.transform).GetComponent<EffectSegsgs>();
                    pp.Add(e);
                    e.key = x.Key;
                    e.name.text = x.Key; 
                    e.color.text = x.Value;
                    e.UpdateDisplayCOlor();
                }
                break;
        }

        UpdateMenus();
    }

    public void ASpawnNewEffectSegs()
    {
        var e = Instantiate(wankerfuckerchild, wankerfucker.transform).GetComponent<EffectSegsgs>();
        pp.Add(e);
        e.key = "";
        e.name.text = "";
        e.color.text = "FFFFFF";
        e.UpdateDisplayCOlor();
    }


    public TextMeshProUGUI pshexballs;
    public void SetCardFromRawEdit()
    {
        try
        {
            LoadCardFromText(rawshit.text, 1);
            pshexballs.text = "";
        }
        catch
        {
            pshexballs.text = "<b>- Invalid Card Data -</b>";
        }
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

        var x = RandomFunctions.Instance.StringToList(cd.data[$"Action{applu + 1}"]);
        if (x.Count > 0 && x[0] == "") x.RemoveAt(0);
        switch (modlu)
        {
            default:
                x.Add(e);
                break;
            case 1:
                x[gggg] = e;
                break;
        }
        cd.data[$"Action{applu + 1}"] = RandomFunctions.Instance.ListToString(x);

        drp3.text = "";
        Carder.Instance.RenderCard(cd);
        checks[5] = false;
        UpdateActionLists();
        UpdateMenus();
    }

    public void SwapAction(int i)
    {
        var cd = Carder.Instance.CurrentCard;

        var a = cd.data[$"Action{i + 1}"];
        cd.data[$"Action{i + 1}"] = cd.data[$"Action{i + 2}"];
        cd.data[$"Action{i + 2}"] = a;
        a = cd.data[$"Grid{i + 1}"];
        cd.data[$"Grid{i + 1}"] = cd.data[$"Grid{i + 2}"];
        cd.data[$"Grid{i + 2}"] = a;
        Carder.Instance.RenderCard(cd);
    }



    public void PickFile(int i)
    {
        StartCoroutine(OpenFileEELol(i));
    }
    string readout = "";

    public void SetImage(string e)
    {
        imagefuiield.text = e;
        UpdateImage(e, 0);
    }
    public void SetBGImage(string e)
    {
        bgfuiield.text = e;
        UpdateImage(e, 1);
    }

    public void UPI()
    {
        if(imagefuiield.text == "")
        {
            sex.sprite = spsps;
            return;
        }
        UpdateImage(imagefuiield.text, 0);
    }
    public void UPI2()
    {
        if (bgfuiield.text == "")
        {
            hotsex.sprite = spsps;
            return;
        }
        UpdateImage(bgfuiield.text, 1);
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


    int gggg = -1;
    public void EditAction(int i, string action)
    {
        gggg = i;
        var cd = Carder.Instance;
        var l = RandomFunctions.Instance.StringToList(cd.CurrentCard.data[action]);
        if (l.Count > 0 && l[0] == "") l.RemoveAt(0);
        var ac = new ActionFart(l[i]);
        GoToAdder(int.Parse(action[action.Length-1].ToString())-1, 1);
        if (ValidEffects.ContainsKey(ac.action))
        {
            for(int z = 0; z < ValidEffects.Count; z++)
            {
                if (ValidEffects.ElementAt(z).Key == ac.action)
                {
                    drp1.value = z;
                    break;
                }
            }
        }
        if (ValidMods.Contains(ac.mod)) drp2.value = ValidMods.IndexOf(ac.mod) + 1;
        drp3.text = ac.amount.ToString();
        if (ac.amount == 0) drp3.text = "";
        if (ac.amount == -1) drp3.text = "";
    }


    public void LoadCardFromText(string e) { LoadCardFromText(e,0); }

    public void LoadCardFromText(string e, int mod)
    {
        if(mod == 0)
        {
            checks[3] = false;
            checks[4] = false;
            checks[5] = false;
        }
        string a = Carder.Instance.CurrentCard.data["ImagePath"];
        string b = Carder.Instance.CurrentCard.data["BGPath"];
        var card = new Card(e);
        namefuiield.text = card.data["Name"];
        imagefuiield.text = card.data["ImagePath"];
        bgfuiield.text = card.data["BGPath"];
        descfuiield.text = card.data["Description"];
        healthfuiield.text = card.data["Health"];
        myballs[0].text = card.data["NameColor"];
        myballs[1].text = card.data["DescriptionColor"];
        myballs[2].text = card.data["HealthColor"];
        myballs[3].text = card.data["ImageBGColor"];
        myballs[4].text = card.data["BGColor"];
        myballs[5].text = card.data["GridBGColor"];
        myballs[6].text = card.data["GridSelfColor"];
        myballs[7].text = card.data["GridMoveColor"];
        myballs[8].text = card.data["GridInfColor"];
        myballs[9].text = card.data["GridNoneColor"];
        Carder.Instance.CurrentCard = card;
        Carder.Instance.RenderCard(Carder.Instance.CurrentCard);
        if(mod==0)
        GoToExclusive(0);
        ready = false;  
        if(a != card.data["ImagePath"])
        {
            UpdateImage(imagefuiield.text, 0);
            if(b != card.data["BGPath"])
            {
                StartCoroutine(WaitForScriggins());
            }
        }
        else
        {
            if (b != card.data["BGPath"])
            {
                UpdateImage(bgfuiield.text, 1);
            }
        }
        if(mod==0)
        UpdateMenus();
    }
    bool ready = false;
    public IEnumerator WaitForScriggins()
    {
        yield return new WaitUntil(() => { return ready; });
        UpdateImage(bgfuiield.text, 1);
    }

    public void UpdateImage(string e = "", int i = 0)
    {
        if (e == "") e = imagefuiield.text;
        StartCoroutine(cummer(e, i));
    }
    public IEnumerator cummer(string e, int i)
    {
        ready = false;
        if (FileSystem.Instance.DDH.Count < 1) FileSystem.Instance.DDH.Insert(0, new DownloadDataHandler());
        if (e.ToLower().Contains(".png") || e.ToLower().Contains(".jpg") || e.ToLower().Contains(".jpeg"))
        {
            Debug.Log("Valid Image");
            StartCoroutine(FileSystem.Instance.GetImage(e, 0));

            yield return new WaitUntil(() => { return FileSystem.Instance.DDH[0].CompletedDownload; });
            Debug.Log("Image Found");
            if (!FileSystem.Instance.DDH[0].ErrorLol && FileSystem.Instance.DDH[0].Texture != null)
            {
                Debug.Log("Doing ur mom");
                var tex = (Texture2D)FileSystem.Instance.DDH[0].Texture;
                Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
                if (i == 0)
                {
                    sex.sprite = sprite;
                    Carder.Instance.CurrentCard.data["ImagePath"] = e;
                }
                else
                {
                    hotsex.sprite = sprite;
                    Carder.Instance.CurrentCard.data["BGPath"] = e;
                }
            }
            else
            {
                Debug.Log("Failed doing mom");
                if (i == 0)
                {
                    sex.sprite = spsps;
                    Carder.Instance.CurrentCard.data["ImagePath"] = "";
                }
                else
                {
                    hotsex.sprite = spsps;
                    Carder.Instance.CurrentCard.data["BGPath"] = "";
                }
            }
        }
        else
        {
            Debug.Log("Faailed valid file");
            if (i == 0)
            {
                sex.sprite = spsps;
                Carder.Instance.CurrentCard.data["ImagePath"] = "";
            }
            else
            {
                hotsex.sprite = spsps;
                Carder.Instance.CurrentCard.data["BGPath"] = "";
            }
        }
        ready = true;
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
            case 1:
                switch (readout)
                {
                    case "BAD":
                        SetBGImage("");
                        break;
                    default:
                        SetBGImage(readout);
                        break;
                }
                break;
        }
    }
}
