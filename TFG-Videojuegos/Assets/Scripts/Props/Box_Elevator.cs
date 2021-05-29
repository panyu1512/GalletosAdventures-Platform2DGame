using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_Elevator : MonoBehaviour
{
    // Variable que almacena la animación del trampolín
    public Animator animacion;

    // Variable que almacena la fuerza del salto que le aplicaremos a nuestro jugador.
    public float fuerzaSalto;

    public AudioSource sonidoEmpuje;

    // Función que nos permitirá saber si el trampolín colosiona con el objeto player.
    private void OnCollisionEnter2D(Collision2D colision) {
        if(colision.transform.CompareTag("jugador")){
            // Al colisionar aplicamos una fuerza vertical a nuestro objeto player
            colision.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            
            // Activamos la animación del trampoline del
            animacion.Play("BoxElevator_Jump");

            sonidoEmpuje.Play();
        }
    }
}
