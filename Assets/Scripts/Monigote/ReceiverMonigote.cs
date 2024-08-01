using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ROS2{

public class ReceiverMonigote : MonoBehaviour
{
    // public GameObject Head0;
    // public GameObject Neck1;
    // public GameObject RightShoulder2;
    // public GameObject LeftShoulder3;
    // public GameObject RightElbow4;
    // public GameObject LeftElbow5;
    // public GameObject RightHand6;
    // public GameObject LeftHand7;
    // public GameObject Pelvis8;
    // public GameObject RightKnee9;
    // public GameObject LeftKnee10;
    // public GameObject RightFeet11;
    // public GameObject LeftFeet12;
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<more_interfaces.msg.PointArray> chatter_sub;
    private Vector3 [] Vectores;
  
    public GameObject [] Arrays;

   // public static object lock1 = new object();
   // private int n;


    void Start()
    {
       ros2Unity = GetComponent<ROS2UnityComponent>(); 
       Vectores = new Vector3[13];
      // n = 0;
        
       // Arrays = new GameObject[13];

    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 [] vectores;
        if (ros2Node == null && ros2Unity.Ok())
        {   
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNodeMonigote");
            chatter_sub = ros2Node.CreateSubscription<more_interfaces.msg.PointArray>("topic", 
            msg => parse(msg)); 
        }
        //lock(lock1){
            //n--;
            for(int i = 0 ; i < 13; i++){
                Arrays[i].transform.position = Vectores[i];
                Debug.Log(Vectores[i]);       
            }   //Debug.Log(i +"i");  
        //}
    }       

    void parse(more_interfaces.msg.PointArray msg)
    {     
        //lock(lock1){
            //if(n == 0){
                //n++;
                for(int i = 0 ; i < 13; i++)
                {  
                    Vectores[i] = new Vector3 ((float)msg.Points[i].X, (float)msg.Points[i].Y, (float)msg.Points[i].Z);
                
                    //Debug.Log(i);
                }
                
            //}
        //}


    }
}
}
