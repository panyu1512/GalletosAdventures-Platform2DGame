using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageToPlayer : MonoBehaviour
{
    public GameObject jugador;

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("jugador")){
            jugador.GetComponent<PlayerController>().JugadorMuerto();
        }
    }    
}
