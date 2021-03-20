using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{

    public GameObject dialogo; 
    private bool enRango;
    public bool aux = true;

    // Update is called once per frame
    void Update()
    {
        if(enRango == true && aux == true){
            dialogo.SetActive(true);
        }
        else{
            dialogo.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            Debug.Log("En rango");
            enRango = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            Debug.Log("Fuera rango");
            enRango = false;
            aux = false;
        }
    }
}
