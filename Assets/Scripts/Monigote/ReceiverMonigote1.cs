using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ROS2{

public class ReceiverMonigote1 : MonoBehaviour
{
    // public GameObject Head0;
    // public GameObject Neck1;
    // public GameObject RightShoulder2;
    // public GameObject RightElbow3;
    
    // public GameObject RightHand4;
    // public GameObject LeftShoulder5;
    // public GameObject LeftElbow6;
    // public GameObject LeftHand7;
    // public GameObject Pelvis8;
    // public GameObject PelvisRightSide9;
    // public GameObject RightKnee10;
    // public GameObject RightFeet11;
    // public GameObject PelvisLeftSide12;
    // public GameObject LeftKnee13;
    // public GameObject LeftFeet14;

    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<sensor_msgs.msg.PointCloud2> chatter_sub;
    private Vector3 [] Vectores;
  
    public GameObject [] Arrays;

   // public static object lock1 = new object();
    private int N;
    private int Lock;


    void Start()
    {
       ros2Unity = GetComponent<ROS2UnityComponent>(); 
       Vectores = new Vector3[30];
      // n = 0;
      Lock = 2;
        
       // Arrays = new GameObject[13];

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 [] vectores;
        if (ros2Node == null && ros2Unity.Ok())
        {   
            Debug.Log("primero"); 
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNodeMonigote");
            chatter_sub = ros2Node.CreateSubscription<sensor_msgs.msg.PointCloud2>("/processed/points/body", 
            msg => parse(msg)); 

            //lock(lock1){
            //n--;
            
        
        }
        Debug.Log("array"); 
        if(Lock == 2){
        for(int i = 0 ; i < N; i++){
                if((i < Arrays.Length) ){

                
                Arrays[i].transform.position = Vectores[i];
               // Debug.Log(Vectores[i] + "hiiiii");       
                }
            }
          Lock = 0;    
         }
        //}
    }       

    void parse(sensor_msgs.msg.PointCloud2 msg)
    {    Debug.Log("parse");  
        if(Lock == 0){
            Lock = 1;
            Debug.Log("parse"); 
            Vectores = PointCloud2toVector(msg.Data);
            
        }

    }
    Vector3 [] PointCloud2toVector(byte[] data){
        
        Vector3 [] sol = new Vector3 [data.Length / 12];
        float x, y, z;
        Debug.Log(data.Length);  
        for(int i = 0; i < data.Length; i += 12){
            x = System.BitConverter.ToSingle(data, i);
            y = System.BitConverter.ToSingle(data, i+4);
            z = System.BitConverter.ToSingle(data, i+8);
            sol[i/12] = new Vector3 (x,y,z);
          //  Debug.Log(sol[i/12]);     
          N = sol.Length;
        }
        Lock = 2;
        return sol;


    }
}
}
