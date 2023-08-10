using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SistemaRecoleccion : MonoBehaviour
{
    public Text totales;
    public int cantidadBombillos;
    public int bombillosRecolectados = 0;
    public AudioSource sintrampas;
    public UnityEvent recoleccionCompleta;

    void Start()
    {
        cantidadBombillos = GameObject.FindGameObjectsWithTag("Bombillo").Length;
        ActualizarTextoTotales();

    }

    public void EvaluarRecoleccion()
    {
        bombillosRecolectados++;

        if (bombillosRecolectados == cantidadBombillos)
        {
            recoleccionCompleta.Invoke();
            // Buscar todos los GameObjects con el tag "Morir" y establecer setactive false
            GameObject[] objetosMorir = GameObject.FindGameObjectsWithTag("Morir");
            foreach (GameObject objeto in objetosMorir)
            {
                objeto.SetActive(false);
                sintrampas.Play();
            }
            
        }
        else
        {
            // Encontrar y activar objetos con el tag "Morir"
            GameObject[] objetosMorir = GameObject.FindGameObjectsWithTag("Morir");
            foreach (GameObject objeto in objetosMorir)
            {
                objeto.SetActive(true);
                
            }
        }

        ActualizarTextoTotales();
    }

    void ActualizarTextoTotales()
    {
        totales.text = bombillosRecolectados + "/" + cantidadBombillos;
    }
}