using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPersonaje : MonoBehaviour
{
    private int vida;
    public float velocidadMovimiento = 5f;
    public float fuerzaSalto = 7f;

    public Vector3 posicionInicio { get; set; }

    private bool enElsuelo = false;
    private Rigidbody2D cuerpoRigido;
    private Animator animaciones;
    private AudioSource audioSalto;

    public GameObject[] corazones;
    public void GameOver(){
        SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
    }   
    void Awake()
    {
        vida = corazones.Length;
        posicionInicio = transform.position;
        cuerpoRigido = GetComponent<Rigidbody2D>();   
        animaciones = GetComponent<Animator>();
        audioSalto = GetComponent<AudioSource>();
    }

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        cuerpoRigido.velocity = new Vector2(movimientoHorizontal * velocidadMovimiento, cuerpoRigido.velocity.y);

        if (Input.GetButtonDown("Jump") && enElsuelo)
        {
            audioSalto.Play();
            cuerpoRigido.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            enElsuelo = false;
        }

        if (movimientoHorizontal > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (movimientoHorizontal < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        animaciones.SetInteger("Salto", (int) cuerpoRigido.velocity.y);
        animaciones.SetBool("Piso", enElsuelo);

        if(enElsuelo)
            animaciones.SetFloat("MovimientoHorizontal", Mathf.Abs(movimientoHorizontal));

        if(vida < 1)
        {
            Destroy(corazones[0].gameObject);
            GameOver();
        }
        else if (vida < 2)
        {
            
            Destroy(corazones[1].gameObject);
            
        }
        else if (vida < 3)
        {
            
            Destroy(corazones[2].gameObject);
            
        }
    }

    void OnCollisionStay2D (Collision2D collision)
    {
        enElsuelo = collision.gameObject.CompareTag("Suelo");

        if (collision.gameObject.CompareTag("Morir"))
            Reinicio();
            
    }

    void Reinicio()
    {
        vida--;
        animaciones.Play("Hit");
        cuerpoRigido.velocity = Vector2.zero;
        cuerpoRigido.angularVelocity = 0;
        cuerpoRigido.bodyType = RigidbodyType2D.Static;
        transform.position = posicionInicio;
        cuerpoRigido.bodyType = RigidbodyType2D.Dynamic;
    }
}

