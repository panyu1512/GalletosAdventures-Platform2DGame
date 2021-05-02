using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTreadmill : MonoBehaviour
{
    public float fuerzaCinta;

    public GameObject jugador;

    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.transform.CompareTag("jugador")){
            // Al colisionar aplicamos una fuerza vertical a nuestro objeto player
            jugador.GetComponent<ConstantForce2D>().enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D colision) {
        if(colision.transform.CompareTag("jugador")){
            // Al colisionar aplicamos una fuerza vertical a nuestro objeto player
            jugador.GetComponent<ConstantForce2D>().enabled = false;
        }
    }
}
