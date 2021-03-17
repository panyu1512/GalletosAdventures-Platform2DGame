using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dañoObjetos : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("jugador")){
            Debug.Log("HE muerto!");
        }   
    }
}
