using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escaleras : MonoBehaviour
{
    private float vertical;
    public  float velocidad;
    private bool EsEscalera;
    private bool Escalando;
    public string VerticalY;

    public Rigidbody2D rb2D;

    void Update()
    { 
        //Comando para obtener los controles del movimiento, en este caso, vertical.
        vertical = Input.GetAxis(VerticalY);
        //Si EsEscalera es verdadero, Escalando es verdadero, y por medio de Mathf, se da el movimiento vertical.
        if(EsEscalera && Mathf.Abs(vertical) > 0f)
        {
            Escalando = true;
        }
    }

    void FixedUpdate()
    {
        //Cuando Escalando es verdadero, significa que el jugador puede por medio del rigidbody ejecutar un movimiento vertical con el VerticalInput.
        if(Escalando)
        {
        rb2D.gravityScale=0f;//Cuando el jugador está escalando, la gravedad es cero para permitir su movimiento.
        rb2D.velocity = new Vector2(rb2D.velocity.x, vertical * velocidad);
        }
        else{
            rb2D.gravityScale = 1f;//cuando no está escalando, la gravedad vuelve a la normalidad.
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //las escaleras poseen este tag, cuando el jugador se acerca a un objeto con este tag se le habilita la funcion de escalar.
        if(collision.CompareTag("Escaleras"))
        {
           EsEscalera = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Escaleras"))
        {
            //cuando el jugador sale del area del colider del objeto que posee el tag, la funcion de escalar es inhabilitada.
             EsEscalera = false;
             Escalando = false;
        }
    }
    
}
