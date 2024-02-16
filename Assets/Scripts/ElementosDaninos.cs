using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementosDaninos : MonoBehaviour
{

    private Animator _animator;
    public MovimientoJugador movimientoJugador;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
     
    }
    private void OnTriggerEnter(Collider other)
    {
       
    }
}

