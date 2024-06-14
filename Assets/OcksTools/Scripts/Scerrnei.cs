using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scerrnei : MonoBehaviour
{
    public Camera camera;


    public int resWidth = 1038;
    public int resHeight = 1438;
    public void TakeHiResShot()
    {
        RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
        camera.targetTexture = rt;
        Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
        camera.Render();
        RenderTexture.active = rt;
        screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
        camera.targetTexture = null;
        RenderTexture.active = null; // JC: added to avoid errors
        Destroy(rt);
        byte[] bytes = screenShot.EncodeToPNG();
        System.IO.File.WriteAllBytes("D:\\UGameBuilds\\Sex2\\"+"a2.png", bytes);
    }

    void LateUpdate()
    {
        if (Input.GetKeyDown("k"))
        {
            TakeHiResShot();
        }
    }
}
