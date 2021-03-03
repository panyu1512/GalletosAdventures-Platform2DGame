using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void ModoCampaña(){
        //SceneManagement.LoadScene()
    }

    public void ModoSpeedRun(){
        //SceneManagement.LoadScene()
    }

    //Función que nos permitirá salir del juego al pulsar el botón de Salir
    public void Salir(){
        Debug.Log("HAS SALIDO DEL JUEGO!");
        Application.Quit();
    }
}

