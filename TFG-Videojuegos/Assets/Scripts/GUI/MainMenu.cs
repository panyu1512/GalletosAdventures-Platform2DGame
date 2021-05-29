using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource sonidoBoton;

    //Función que nos permitirá ir a la escena SelectLevelMenu al pulsar el botón ModoCampaña
    public void ModoCampaña(){
        sonidoBoton.Play();
        SceneManager.LoadScene("SelectLevelMenu");
    }

    public void ModoSpeedRun(){
        sonidoBoton.Play();
        Invoke("SpeedRun", 1f);
    }

    //Función que nos permitirá salir del juego al pulsar el botón de Salir
    public void Salir(){
        sonidoBoton.Play();
        
        Debug.Log("HAS SALIDO DEL JUEGO!");
        Application.Quit();
    }

    public void SpeedRun(){
        SceneManager.LoadScene("SpeedRun");
    }
}

