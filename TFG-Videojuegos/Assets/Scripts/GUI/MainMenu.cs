using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Función que nos permitirá ir a la escena SelectLevelMenu al pulsar el botón ModoCampaña
    public void ModoCampaña(){
        
        SceneManager.LoadScene("SelectLevelMenu");
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

