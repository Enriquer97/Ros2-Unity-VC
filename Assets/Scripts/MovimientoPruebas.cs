using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPruebas : MonoBehaviour
{
    private float movementSpeed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * movementSpeed * 2.5f;
        transform.position = new Vector3 (transform.position.x,2.0f,transform.position.z);
    }
}
