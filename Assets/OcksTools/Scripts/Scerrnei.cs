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
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        var e = camera.targetTexture;
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        var ww = Gamer.Instance.settings["ImageExportPath"] + $"/{Carder.Instance.CurrentCard.data["Name"]}.png";
        System.IO.File.WriteAllBytes(ww, bytes);
        Gamer.Instance.SendNotif($"Rendered Card to \n\"{ww}\"");
        if (e != null) camera.targetTexture = e;
        maincamera.Render();

    }
}
