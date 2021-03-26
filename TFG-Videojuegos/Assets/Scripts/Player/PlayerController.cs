using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    
    // Variable que almacenará el componente Rigidbody2D
    private Rigidbody2D rb;

    // Variable que almacenará el componente Animator del Player
    private Animator anim;

    private Collider2D colliderJugador;

    // Variable que almacena la posición del personaje;
    public Transform suelo;

    // Variable que nos permitirá decir en que capa queremos que colisione nuestro objeto jugador
    public LayerMask mascaraSuelo;

    public GameObject[] objetos;


    // Variable que almacenará la dirección
    private float inputDireccionMovimiento;

    // Variable que almacena la velocidad del personaje
    public float velocidadMovimiento = 6.5f;

    // Variable que almacena la fuerza del salto
    public float fuerzaSalto = 13.0f;

    public float fuerzaMuerte;

    // Variable que almacena el radio para comprobar si dentro de dicho radio el personaje colisióna con algún objeto tipo suelo.
    private float radio = 0.06f;


    // Booleano para comprobar si el personaje mira a la izquierda o la derecha
    private bool miraDerecha = true;

    // Booleano para saber si el personaje esta caminando 
    private bool estaCaminando;

    // Booleano para saber si el personaje esta en el suelo
    private bool estaEnSuelo = true;

    private bool vivo;
    
    private bool estaMuerto;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        colliderJugador = GetComponent<Collider2D>();

        vivo = true;

    }

    // Update is called once per frame
    void Update()
    {
        if(vivo == true){
            ComprobarInput();
            ComprobarDireccionMovimiento();
            actualizarAnimaciones();
        }

    }

    // FixedUpdate es llamada ...
    private void FixedUpdate() {
        if(vivo == true){
            AplicarMovimiento();

            estaEnSuelo = Physics2D.OverlapCircle(suelo.position, radio, mascaraSuelo);
        }
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

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("spikes") || other.transform.CompareTag("caida")){
            JugadorMuerto();
        }
    }
    // Función que realiza la animación de muerte del jugador
    void JugadorMuerto(){
        estaMuerto = true;
        anim.SetBool("death", estaMuerto);

        vivo = false;

        colliderJugador.enabled = false;
        foreach (GameObject obj in objetos)
            obj.SetActive(false);

        rb.gravityScale = 2f;
        rb.AddForce(transform.up * fuerzaMuerte, ForceMode2D.Impulse);

        // Mediante la función StartCoroutine relantizaremos la función de RespawnJugador.
        StartCoroutine("RespawnJugador");
    }

    // Resetearemos las variables y cargaremos de nuevo la escena.
    IEnumerator RespawnJugador(){
        yield return new WaitForSeconds(1f);
        estaMuerto = false;
        anim.SetBool("death", estaMuerto);

        colliderJugador.enabled = true;
        foreach (GameObject obj in objetos)
            obj.SetActive(true);

        rb.gravityScale = 4f;

        yield return new WaitForSeconds(0.01f);
        vivo = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

}
