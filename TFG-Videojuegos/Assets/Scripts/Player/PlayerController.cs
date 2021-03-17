using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    // Variable que almacenará el componente Rigidbody2D
    private Rigidbody2D rb;

    // Variable que almacenará el componente Animator del Player
    private Animator anim;

    // Variable que almacena la posición del personaje;
    public Transform suelo;

    // Variable que nos permitirá decir en que capa queremos que colisione nuestro objeto jugador
    public LayerMask mascaraSuelo;


    // Variable que almacenará la dirección
    private float inputDireccionMovimiento;

    // Variable que almacena la velocidad del personaje
    public float velocidadMovimiento = 6.5f;

    // Variable que almacena la fuerza del salto
    public float fuerzaSalto = 13.0f;

    // Variable que almacena el radio para comprobar si dentro de dicho radio el personaje colisióna con algún objeto tipo suelo.
    private float radio = 0.06f;


    // Booleano para comprobar si el personaje mira a la izquierda o la derecha
    private bool miraDerecha = true;

    // Booleano para saber si el personaje esta caminando 
    private bool estaCaminando;

    // Booleano para saber si el personaje esta en el suelo
    private bool estaEnSuelo = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ComprobarInput();
        ComprobarDireccionMovimiento();
        actualizarAnimaciones();

    }

    // FixedUpdate es llamada ...
    private void FixedUpdate() {
        AplicarMovimiento();

        estaEnSuelo = Physics2D.OverlapCircle(suelo.position, radio, mascaraSuelo);
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
        if(estaEnSuelo){
            rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);            
        }
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

        if(rb.velocity.x != 0){
            estaCaminando = true;
        }
        else{
            estaCaminando = false;
        }
    }

    private void CambiarDireccion(){
        miraDerecha = !miraDerecha;
        transform.Rotate(0f, 180f, 0f);
    }

    // Función que nos permitirá actualizar las animaciones del personaje
    private void actualizarAnimaciones(){
        anim.SetBool("isWalking", estaCaminando);
    }
}
