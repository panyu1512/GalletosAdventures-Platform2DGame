using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Variable que almacena la animación
    public Animator animator;

    public bool On = false;

    void Start() {
        animator = GetComponent<Animator>();
    }

    // Función que nos permitirá saber si el jugador interactua con la palanca. De ser así, activará la plataforma.
    private void OnTriggerStay2D(Collider2D col) {
        if(col.CompareTag("jugador")) {
            if(Input.GetKeyDown(KeyCode.F) && On == false){
                animator.Play("LeverOn");
                On = true;
            }
        }
    }
}
