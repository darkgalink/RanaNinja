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

    public UnityEvent recoleccionCompleta;

    void Start()
    {
        cantidadBombillos = GameObject.FindGameObjectsWithTag("Bombillo").Length;
        totales.text = cantidadBombillos + "/" + bombillosRecolectados;
    }

    public void EvaluarRecoleccion()
    {
        bombillosRecolectados++;
        if (bombillosRecolectados == cantidadBombillos)
            recoleccionCompleta.Invoke();
        totales.text = cantidadBombillos + "/" + bombillosRecolectados;
    }
    
}
