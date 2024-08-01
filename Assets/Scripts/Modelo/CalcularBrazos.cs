using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalcularBrazos : MonoBehaviour
{

private float DistHombroCodo = 0.1292229f;
private float DistCodoMano = 0.2761446f;
private Vector3 PosHombro;
private Vector3 RPosHombro;
private Vector3 RPosCodo;
private Vector3 RPosMano;
private float RDistHombroCodo;
private float RDistCodoMano;
private Vector3 VectorDirHombroCodo;
private Vector3 VectorDirCodoMano;

    // Start is called before the first frame update
    void Start()
    {
      
        //float PosHombro = transform
        VectorDirHombroCodo = (RPosCodo - RPosHombro) / RDistHombroCodo;
        VectorDirCodoMano =  (RPosMano - RPosCodo ) /RDistCodoMano;
     
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 posCodo = PosHombro +(DistHombroCodo * VectorDirHombroCodo);
        
        Vector3 posMano = posCodo + (DistCodoMano * VectorDirCodoMano);

    }
}
