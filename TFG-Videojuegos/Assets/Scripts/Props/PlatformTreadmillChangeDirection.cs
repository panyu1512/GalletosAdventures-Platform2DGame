using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTreadmillChangeDirection : MonoBehaviour
{
    public GameObject jugador;

    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.transform.CompareTag("jugador")){
            jugador.GetComponent<ConstantForce2D>().relativeForce = new Vector2(-200, 0);
            jugador.GetComponent<ConstantForce2D>().enabled = true;
        }
    }

    private void OnCollisionExit2D(Collision2D colision) {
        if(colision.transform.CompareTag("jugador")){
            jugador.GetComponent<ConstantForce2D>().relativeForce = new Vector2(200, 0);
            jugador.GetComponent<ConstantForce2D>().enabled = false;
        }
    }
}
