using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoErraticoPrueba : MonoBehaviour
{
    private float Phase = 0;
    // Start is called before the first frame update
    
        void Update()
        {
            if (Input.anyKeyDown)
            {
            if (Phase == 0)
            {
                transform.position = new Vector3 (0f,1.65f,0.5f);
                
                Phase++;
                }else if(Phase == 1){
                 transform.position = new Vector3 (3,5,1);
                
                 Phase++;
                }else{
                 transform.position = new Vector3 (1,3,1);
                
                 Phase = 0;
            }
        }
    

    // Update is called once per frame
    // IEnumerator ExampleCoroutine()
    // {
    //     if(Phase == 0){
    //         transform.position = new Vector3 (2,5,0);
    //         yield return new WaitTime(2);
    //         Phase++;
    //     }else if(Phase == 1){
    //         transform.position = new Vector3 (3,5,1);
    //         yield return new WaitTime(2);
    //         Phase++;
    //     }else{
    //         transform.position = new Vector3 (1,3,1);
    //          yield return new WaitTime(2);
    //         Phase = 0;
    //     }
 }
}
