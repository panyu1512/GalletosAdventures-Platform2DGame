using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Variable que almacenará la dirección
    private float inputDireccionMovimiento;

    // Variable que almacenará el componente Rigidbody2D
    private Rigidbody2D rb;

    // Variable que almacena la velocidad del personaje
    private float velocidadMovimiento = 10.0f;

    // Variable que almacena la fuerza del salto
    private float fuerzaSalto = 16.0f;

    // Booleano para comprobar si el personaje mira a la izquierda o la derecha
    private bool miraDerecha = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarInput();
        ComprobarDireccionMovimiento();
    }

    // FixedUpdate es llamada ...
    private void FixedUpdate() {
        AplicarMovimiento();
    }

    // Función que comprobará la dirección del personaje
    private void ComprobarInput(){

        inputDireccionMovimiento = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump")){
            Saltar();
        }
    }

    //Función que permitirá saltar a el personaje
    private void Saltar(){
        rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);
    }

    // Función que aplicará el movimiento lateral al personaje
    private void AplicarMovimiento(){
        rb.velocity = new Vector2(velocidadMovimiento * inputDireccionMovimiento, rb.velocity.y);
    }

    // Función que permitara que el personaje mire a una direccion correspondiente a la que se esta moviendo
    private void ComprobarDireccionMovimiento(){
        if(miraDerecha && inputDireccionMovimiento < 0){
            CambiarDireccion();
        }
        else if (!miraDerecha && inputDireccionMovimiento > 0){
            CambiarDireccion();
        }
    }

    private void CambiarDireccion(){
        miraDerecha = !miraDerecha;
        transform.Rotate(0f, 180f, 0f);
    }
}
