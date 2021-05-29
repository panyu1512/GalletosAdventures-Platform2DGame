using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject finJuegoUI;
    public bool UIactivo = false;

    public GameObject jugador;


    public void Update(){
        if(UIactivo == true){
            if(Input.anyKeyDown){
                Invoke("CargarMenu",0);
            }
            Destroy(jugador);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            finJuegoUI.SetActive(true);
            UIactivo = true;
        }    
    }
    public void CargarMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
