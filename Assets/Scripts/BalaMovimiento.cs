using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaMovimiento : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public float velocidad;
    private Vector2 Direction;
    
    public void Start()
    {
       rb2D = GetComponent<Rigidbody2D>(); //obtiene el componente Rigidbody para obtener las fisicas del prefab de la bala.
    }

    private void FixedUpdate ()
    { 
        rb2D.velocity = Direction * velocidad;//Aquí, por medio de el Rigidbody, se le aplica movimiento por medio de una direccion dada por Vector2 y una velocidad establecida.
    }

   public void SetDirection(Vector2 direction)
    {
        Direction = direction; //Con esta funcion se le da la direccion al Vector2 declarado, con otro Vector2 que define la direccion en el eje X.
    }

    public void DestruirBala()
    {
        Destroy(gameObject); //Esta funcion es para que la bala no exista eternamente, sino que pasado cierto tiempo, se destruya el objeto.
    }


    //este codigo declarado es la mecanica de disparo tanto del jugador como del enemigo para que se puedan hacer daño, pero quedó en pausa.

   private void OnTriggerEnter2D(Collider2D collision)
    {
        MovimientoJugador jugador = collision.GetComponent<MovimientoJugador>();
        ComportamientoEnemigo enemigo = collision.GetComponent<ComportamientoEnemigo>();
        if(jugador != null)
        {
            jugador.Golpe(1);
        }
        if(enemigo != null)
        {
            enemigo.Golpe(1);
        }
        DestruirBala();
    }
}



