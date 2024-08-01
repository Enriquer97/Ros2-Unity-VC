using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace ROS2{
public class ImageReceiver1 : MonoBehaviour
{
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<sensor_msgs.msg.Image> chatter_sub;
    public RenderTexture RenTex;
    private byte [] Data;
    private int C;
    private int Width;
    private int Height;
 
    // Start is called before the first frame update
    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>(); 
        C = 0;
        RenderTexture.active = RenTex;
        
        LoadStoreActionDebugModeSettings.LoadStoreDebugModeEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("hola");
        if (ros2Node == null && ros2Unity.Ok())
        {   
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNodeImage1");
            chatter_sub = ros2Node.CreateSubscription<sensor_msgs.msg.Image>("camera1", 
            msg => parse(msg)); 
        }
        if(C ==1)
        {
        
        //var imageMemoryStream = new MemoryStream(bytes);
        //Image imFromStream = Image.FromStream(imageMemoryStream);
        //pictureBox1.Image = imFromStream;
        Texture2D tex = new Texture2D(Width, Height);
        
        //tex.SetPixels32(toColor32(Data));
        //tex.Apply();
        //RenTex = new RenderTexture(Width, Height, 32, RenderTextureFormat.ARGB32);
        tex.LoadImage(toRGBA(Data));
        //RenderTexture.active = RenTex;
        Graphics.Blit(tex, RenTex);
        
        Debug.Log("cargada");
        C = 0;
        }
    }
    void parse(sensor_msgs.msg.Image msg)
    {
        if(C == 0){

        C = 1;
        Debug.Log("recibido");
        Width = (int)msg.Width;
        Height =  (int)msg.Height;
        Data = msg.Data;
        
        }

    }
    Color32[] toColor32(byte[] data){

        var colorArray = new Color32[data.Length / 3];
        for(var i = 0; i < data.Length; i += 3)
        {
               var color = new Color32(data[i + 0], data[i + 1], data[i + 2],0);
         colorArray[(i)/3] = color;
        }
        return colorArray;
        
    }
    byte [] toRGBA (byte[] data){
    
        var dataArray = new byte[data.Length + (data.Length / 3)];
        for(var i = 0; i < dataArray.Length; i += 3)
        {
            dataArray[i+(i/3)] = data[i+0];
            dataArray[i+1+(i/3)] = data[i+1];
            dataArray[i+2+(i/3)] = data[i+2+0];
            dataArray[i+3+(i/3)] = 0;
        }
        return dataArray;
    }

   
}
}
