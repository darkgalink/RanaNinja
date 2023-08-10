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
            // Encontrar y activar objetos con el tag "Morir"
            GameObject[] objetosMorir = GameObject.FindGameObjectsWithTag("Morir");
            foreach (GameObject objeto in objetosMorir)
            {
                objeto.SetActive(true);
            } 
            ganar.Play(); // Reproducir el sonido de ganar
            
            // Agregar un retraso de 2.7 segundos antes de cargar el siguiente nivel
            StartCoroutine(CargarSiguienteNivelConRetraso());
        }
    }

    // Corrutina para cargar el siguiente nivel con un retraso
    IEnumerator CargarSiguienteNivelConRetraso()
    {
        yield return new WaitForSeconds(2.7f);
        siguienteNivel();
    }
}