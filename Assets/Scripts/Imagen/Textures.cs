using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textures : MonoBehaviour
{
    private static Texture2D RenderTextureToTexture2D(RenderTexture texture)
{
    var oldRen = RenderTexture.active;
    RenderTexture.active = texture;
    var texture2D = new Texture2D(texture.width, texture.height, TextureFormat.RGBA64, false, false);
    texture2D.ReadPixels(new Rect(0, 0, texture.width, texture.height), 0, 0);
    texture2D.Apply();
    RenderTexture.active = oldRen;
    return texture2D;
}
    private static void CreateImageFiles(Texture2D tex, int index)
    {
        var pngData = tex.EncodeToJPG();
        if (pngData.Length < 1)
        {
            return;
        }
        var path = @"TypePathHere" + index + ".jpg";
       // File.WriteAllBytes(path, pngData);
        //AssetDatabase.Refresh();
}
}
