using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodoPruebas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (0.0f,1.0f,1.0f)* Time.deltaTime * 1.0f;
    }
}
