using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    private AudioSource ganar;

void Awake() {
		ganar = GetComponent<AudioSource>();
}

    void siguienteNivel (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    private void OnCollisionEnter2D (Collision2D other)
    {
        if (other.collider.CompareTag("Player")){
           siguienteNivel();
        }
    }
}