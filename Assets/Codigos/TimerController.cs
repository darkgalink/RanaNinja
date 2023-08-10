using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public Text timerText;
    private float totalTime = 150f; // 2 minutos y 30 segundos en segundos
    private float currentTime;
    public AudioSource tiempo;
    public AudioSource yacasi;
    private bool isTimerRunning = false;
    private bool yacasiPlayed = false;
    private bool shouldChangeColor = false;
    private bool shouldChangeSize = false;

    private void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();

        // Iniciar el contador automáticamente al iniciar la escena
        StartTimer();
    }

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 30f && !yacasiPlayed)
            {
                yacasi.Play();
                yacasiPlayed = true;
            }

            if (currentTime <= 1f)
            {
                currentTime = 0f;
                isTimerRunning = false;
                if (!tiempo.isPlaying)
                {
                    tiempo.Play();
                }
                SceneManager.LoadScene("GameOver");
            }

            UpdateTimerText();

            if (currentTime <= 30f && !shouldChangeColor)
            {
                // Cambiar color del texto cuando se cumple 30f
                timerText.color = Color.red;
                shouldChangeColor = true;
            }

            if (currentTime <= 30f && !shouldChangeSize)
            {
                // Cambiar tamaño del texto cuando se cumple 30f
                timerText.fontSize = (int)(timerText.fontSize * 1.5f);
                shouldChangeSize = true;
            }
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    void UpdateTimerText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
