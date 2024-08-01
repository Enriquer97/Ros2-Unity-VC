using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace ROS2{

public class Ros2Movement1 : MonoBehaviour
{

    private ROS2UnityComponent ros2Unity;
    private ROS2Node ros2Node;
    private ISubscription<more_interfaces.msg.Vector3Array> chatter_sub;
    private Vector3 vector;
    // Start is called before the first frame update
    void Start()
    {
        ros2Unity = GetComponent<ROS2UnityComponent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (ros2Node == null && ros2Unity.Ok())
        {  
          
           
            ros2Node = ros2Unity.CreateNode("ROS2UnityListenerNode");
            chatter_sub = ros2Node.CreateSubscription<more_interfaces.msg.Vector3Array>("topic",
            msg => parse(msg));   
            
        }
        transform.position = vector;
    }
    void parse(more_interfaces.msg.Vector3Array msg)
    {
        
        vector = new Vector3 ((float)msg.Vectors[0].X, (float)msg.Vectors[0].Y, (float)msg.Vectors[0].Z);
    }
}

}
