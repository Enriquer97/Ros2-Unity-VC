using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ROS2{

public class ReceiverModel : MonoBehaviour
{
    // public GameObject Head0;
    // public GameObject Neck1;
    // public GameObject RightHand2;
    // public GameObject RightElbow3;
    // public GameObject RightShoulder4;
    // public GameObject LeftHand5;
    // public GameObject LeftElbow6;
    // public GameObject LeftShoulder7;
    // public GameObject Pelvis8;
    // public GameObject RightFeet9;
    // public GameObject RightKnee10;
    // public GameObject LeftFeet11;
    // public GameObject LeftKnee12;
    private float [] Distances = new float[8]; // primero tip-mid y despues mid-root
    private float ValorOffset;
    
    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<more_interfaces.msg.PointArray> chatter_sub;
    private Vector3 [] Vectores = new Vector3[11];
    public GameObject [] Arrays = new GameObject[11];
    private bool Offset;
   // public static object lock1 = new object();
   // private int n;


    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>(); 
        Vectores = new Vector3[11];
        Offset = true;
      // n = 0;
        
       //Arrays = new GameObject[11];

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            Offset = true;
            Debug.Log("offset recalculado");
        }
        if (ros2Node == null && ros2Unity.Ok())
        {   
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNodeModel");
            chatter_sub = ros2Node.CreateSubscription<more_interfaces.msg.PointArray>("topic", 
            msg => parse(msg)); 
        }
        //lock(lock1){
            //n--;
            for(int i = 0 ; i < 11; i++)
            {
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
                if(Offset)
                {
                    ObtenerOffset(Vectores[0],Vectores[9]);
                    Offset = false;
                }
                for(int i = 0 ; i < 11; i++)
                {  
                    Vectores[i] = new Vector3 ((float)msg.Points[i].X, (float)msg.Points[i].Y, (float)msg.Points[i].Z);
                   
                    if(i == 0)
                    {
                        Vectores[0].y = Vectores[0].y + ValorOffset;
                    }
                    if(i == 4 || i == 7)
                    {
                        EscalarExtremidades(i,0);  
                    }
                    //Debug.Log(i);
                }
                
            //}
        //}


    }
    void EscalarExtremidades(int i, int j){
        
        Vector3 rPosRoot = Vectores[i];
        Vector3 rPosMid = Vectores[i-1];
        Vector3 rPosTip = Vectores[i-2];
        Vector3 posRoot = Arrays[i].transform.position;
        float rDistRootMid = Vector3.Distance(rPosRoot, rPosMid);
        float rDistMidTip = Vector3.Distance(rPosMid,rPosTip);
        Vector3 vectorDirRootMid = (rPosMid - rPosRoot) / rDistRootMid;
        Vector3 vectorDirMidTip =  (rPosTip - rPosMid) / rDistMidTip;
        Vectores[i-1] = posRoot + (Distances[j+1] * vectorDirRootMid);
        Vectores[i-2] = Vectores[i-1] + (Distances[j] * vectorDirMidTip);
    }
    void ObtenerOffset(Vector3 pointHips, Vector3 pointGround)
    {
       float x = pointHips.y - pointGround.y;
       ValorOffset = 0.9979194f - x; 
    }
}
}
