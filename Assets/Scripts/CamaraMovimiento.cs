using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    public GameObject puntoCentral;
    public float OffsetVertical;
    public float OffsetHorizontal;

    void Update()
    {
        if(puntoCentral != null)
        {
        Vector3 position = transform.position;
        position.x = puntoCentral.transform.position.x + OffsetHorizontal;
        position.y = puntoCentral.transform.position.y + OffsetVertical;
        transform.position = position;
        }
    }
}
