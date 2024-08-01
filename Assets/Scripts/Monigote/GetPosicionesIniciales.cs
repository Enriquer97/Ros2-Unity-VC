using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosicionesIniciales : MonoBehaviour
{

    public GameObject StartObject;
    public GameObject EndObject;
    private Vector3 InitialScale;
    // Start is called before the first frame update
    void Start()
    {
        InitialScale = transform.localScale;

        float distancia = Vector3.Distance(StartObject.transform.position, EndObject.transform.position);
        transform.localScale = new Vector3(InitialScale.x, distancia / 2f, InitialScale.z);

        Vector3 middlePoint = (StartObject.transform.position + EndObject.transform.position) / 2f;
        transform.position = middlePoint;

        Vector3 rotationDirection = (StartObject.transform.position - EndObject.transform.position);
        transform.up = rotationDirection;

        Debug.Log(gameObject.name + "\nEscala: " + transform.localScale  );
        Debug.Log("Posicion: " + transform.position + "Rotacion: " + transform.localRotation.eulerAngles);
    }

    // Update is called once per frame
    
}
