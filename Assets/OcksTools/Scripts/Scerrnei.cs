using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scerrnei : MonoBehaviour
{
    public Camera camera;
    public Camera maincamera;


    public int resWidth = 1038;
    public int resHeight = 1438;
    public void TakeHiResShot()
    {
        var f = Mathf.RoundToInt(float.Parse(Gamer.Instance.settings["RenderScale"]) * 100);
        Carder.Instance.Sizer.transform.localScale = Vector3.one* float.Parse(Gamer.Instance.settings["RenderScale"]);
        Debug.Log("renderval: " + f);
        var rw = resWidth * f / 100;
        var rh = resHeight * f / 100;


        RenderTexture rt = new RenderTexture(rw, rh, 24);
        var e = camera.targetTexture;
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(rw, rh, TextureFormat.RGBA32, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, rw, rh), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        var ww = Gamer.Instance.settings["ImageExportPath"] + $"/{Carder.Instance.CurrentCard.data["Name"]}.png";
        System.IO.File.WriteAllBytes(ww, bytes);
        
        Gamer.Instance.SendNotif($"Rendered Card to \n\"{ww}\"");
        if (e != null) camera.targetTexture = e;
        Carder.Instance.Sizer.transform.localScale = Vector3.one;
        camera.Render();
        maincamera.Render();

    }
}
