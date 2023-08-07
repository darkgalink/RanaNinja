using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{

    public void NivelFacil(){
            SceneManager.LoadScene("Nivel1");
        }
    public void NivelMedio(){
            SceneManager.LoadScene("Nivel2");
        } 
    public void NivelDificil(){
            SceneManager.LoadScene("Nivel3");
        }
    public void MenuPrincipal(){
            SceneManager.LoadScene("MenuPrincipal");
        }
    public void ReiniciarNivel(){
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    public void SalidelJuego(){
        Application.Quit();
    }    
    public void Pausa(){
            Time.timeScale = 0f;
        }           
    public void Reanudar(){
            Time.timeScale = 1f;
        }

}
