using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoEnemigo : MonoBehaviour
{
    public GameObject Bala;
    public GameObject jugador;
    public Transform puntoDisparoE;
    private Animator _animator;
    private float UltimoTiro; 
    public int VidaEnemigo = 3;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    void Update()
    {
        if(jugador == null)
        {
            return;
        }
        Vector3 direction = jugador.transform.position - transform.position;
        if(direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(15.0f, 15.0f, 1.0f);
        }else transform.localScale = new Vector3(-15.0f, 15.0f, 1.0f);

        float distance = Mathf.Abs(jugador.transform.position.x - transform.position.x);

        if(distance < 10.0f && Time.time > UltimoTiro + 0.25f)
        {
            Disparar();
            UltimoTiro = Time.time;
        }
    }

    void Disparar()
    {
       Vector3 direction;
            if(transform.localScale.x == 15.0f) direction = Vector3.right;
            else direction = Vector3.left;

            GameObject bala = Instantiate (Bala, puntoDisparoE.position, Quaternion.identity);
            bala.GetComponent<BalaMovimiento>().SetDirection(direction);
    }

    public void Golpe(int puntosDeDanoE)
    {
        _animator.SetTrigger("Hit");
        VidaEnemigo -= puntosDeDanoE;
      if(VidaEnemigo == 0)
      {
        Destroy(gameObject);
      }
    }
}
