using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public static bool juegoPausado = false;

    public GameObject MenuPausaUI;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(juegoPausado){
                Renaudar();
            }else{
                Pausar();
            }
        }
    }

    public void Renaudar(){
        MenuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        juegoPausado = false;
    }

    void Pausar(){
        MenuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        juegoPausado = true;
    }

    public void CargarMenu(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");

    }

    public void Salir(){
        Application.Quit();
        Debug.Log("HAS SALIDO!");
    }
}
