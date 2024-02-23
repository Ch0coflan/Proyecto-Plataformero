using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject balaPrefab;

    [Header("Variables")]
    public string EntradaX;
    public string EntradaY;
    public KeyCode salto;
    public KeyCode ataque;
    public float fuerzaSalto;
    public float velocidad;
    public float HorizontalX;
    public float VerticalY;
    public float rayoD = 0.1f;
    public float UltimoTiro;
    private bool EnSuelo;
    public int Vida = 6;
    private bool EstaVivo = true;
    private int puntosActuales = 0;
    public float orientacion;

    [Header("Componentes")]
    public Transform puntoDisparo;
    private Rigidbody2D _rb2D; 
    private Animator _animator; 


    public ControladorVidas ControladorVidas;
    public ControladorPuntos ControladorPuntos;

    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        ControladorVidas.UpdateLife(Vida);
        ControladorPuntos.UpdatePoints(puntosActuales);
    }
    void Update()
    {
        if (EstaVivo == true)
        { 
            HorizontalX = Input.GetAxisRaw(EntradaX);
            VerticalY = Input.GetAxisRaw(EntradaY);
            if (HorizontalX < 0.0f)
            {
                transform.localScale = new Vector3(-orientacion, orientacion, 1.0f);
            }
            else if (HorizontalX > 0.0f)
            {
                transform.localScale = new Vector3(orientacion, orientacion, 1.0f);
            }
            _animator.SetBool("isRun", HorizontalX != 0.0f);

            Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
            if (Physics2D.Raycast(transform.position, Vector3.down, rayoD))
            {
                EnSuelo = true;
            }
            else EnSuelo = false;

            if (Input.GetKeyDown(ataque) && Time.time > UltimoTiro + 0.25f)
            {
                _animator.SetTrigger("attack");
                Atacar();
                UltimoTiro = Time.time;
            }
            Saltar();
            Muerte();
        }   
        //Reiniciar();
    }

    private void FixedUpdate()
    {
        _rb2D.velocity = new Vector2(HorizontalX * velocidad, _rb2D.velocity.y);
    }

    void Saltar()
    { 
        if (Input.GetKeyDown(salto) && EnSuelo)
        {
            _rb2D.AddForce(Vector2.up * fuerzaSalto);
            _animator.SetBool("isJump", true);
        }

        if(EnSuelo == false)
        {
            _animator.SetBool("isJump", true);
        }
        else
        {
            _animator.SetBool("isJump", false);
        }
    }
    void Atacar()
    {
        Vector3 direction;
        if (transform.localScale.x == orientacion)
        {
            direction = Vector2.right;
        }
        else direction = Vector2.left;
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, Quaternion.identity);
        bala.GetComponent<BalaMovimiento>().SetDirection(direction);
    }
    public void Golpe(int puntosDeDano)
    {
        _animator.SetTrigger("hurt");
        Vida -= puntosDeDano;
        ControladorVidas.UpdateLife(Vida);
       
    }
  void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Axes"))
        {
            Golpe(1);
            _animator.SetTrigger("hurt");
        }

        if (other.CompareTag("Cerezas"))
        {
            Debug.Log("puntos++");
            puntosActuales++;
            ControladorPuntos.UpdatePoints(puntosActuales);
            other.gameObject.SetActive(false);
        }

        if (other.CompareTag("Banano"))
        {
            Debug.Log("vida++");
            Vida++;
            ControladorVidas.UpdateLife(Vida);
            other.gameObject.SetActive(false);
        }
    }
    
    public void Muerte()
    {
        if (Vida == 0)
        {
            EstaVivo = false;
            _animator.SetTrigger("Dead");
        }
        else
        {
            
            EstaVivo = true;
        }
    }

    public void PararSalto()
    {
        _animator.SetBool("isJump", false);
    }


    /*void Reiniciar()
    {
        if (Input.GetKeyDown(reinicio))
        {
            _animator.SetTrigger("idle");
            EstaVivo = true;
            Vida = 5;
        }
    }*/



}










