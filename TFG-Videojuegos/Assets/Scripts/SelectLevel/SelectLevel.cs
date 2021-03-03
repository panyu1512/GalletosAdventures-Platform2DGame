using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectLevel : MonoBehaviour
{
    //Función que nos permitirá ir a la escena MainMenu al pulsar el botón de volver al Menu Principal
    public void MenuPrincipal(){
        
        SceneManager.LoadScene("MainMenu");
    }
}
