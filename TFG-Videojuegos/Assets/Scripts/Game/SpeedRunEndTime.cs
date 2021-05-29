using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpeedRunEndTime : MonoBehaviour
{
    public GameObject finSpeedRunUI;
    public bool UIactivo;    

    void Start(){
        UIactivo = false;
    }

    public void Update(){
        if(UIactivo == true){
            if (Input.GetKey("f")){
                Invoke("CargarMenu",0);
            }
            if (Input.GetKey("r")){
                Invoke("CargarSpeedRun",0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            SpeedRunTimer.instanciar.pararCronometro();
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 600f);
            finSpeedRunUI.SetActive(true);
            UIactivo = true;
        }
    }

    public void CargarMenu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void CargarSpeedRun(){
        SceneManager.LoadScene("SpeedRun");
    }
}
