using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float leftLimit;
    public float rightLimit;
    public int velocidad; 
   


    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();//obtenemos las fisicas por medio del Rigidbody
        rb2D.angularVelocity = 250;//ya que el pendulo produce un angulo a partir de un pivote, debemos indicar la velocidad de movimiento.
    }

    void Update()
    {
        movimientoPendulo();//Ejecuta el movimiento.
        
    }

    void movimientoPendulo()
        //estas condidiones establecen los limites angulares del pendulo, para hacer que cuando se dirija hacia la derecha,
        //su velocidad sea negativa para que vaya hacia la izquiera y viseverza eternamente, y asi produzca el movimiento pendular.
    {
        if(transform.rotation.z < rightLimit && rb2D.angularVelocity > 0 && rb2D.angularVelocity < velocidad)
        {
            rb2D.angularVelocity = velocidad;
        }
        else if(transform.rotation.z > leftLimit && rb2D.angularVelocity < 0 && rb2D.angularVelocity > -velocidad)
        {
            rb2D.angularVelocity = -velocidad;
        }
    }

    
}
