using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public float fuerzaSalto = 15f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        //muy sencillo, si el jugador que posee el tag player se choca con el trampolin, se le aplica una velocidad vertical, que es la que
        //termina dandole ese impulso hacia arriba, como un trampolin.
        if(collision.transform.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
        }
    }

   
}
