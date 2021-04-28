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

    // Variable que almacena la posición del suelo;
    public Transform suelo;

    // Variable que almacena la posición de la pared;
    public Transform pared;

    public Transform spawnPrefab;

    public Transform spawn;

    // Variable que nos permitirá decir en que capa queremos que colisione nuestro objeto jugador
    public LayerMask mascaraSuelo;

    // Variable que nos permitirá decir en que capa queremos que colisione nuestro objeto jugador
    public LayerMask mascaraPared;
    
    public GameObject[] objetos;

    // Varianle que almacenará el objeto con nuestra animación del dash. 
    public GameObject efectoDash;

    public GameObject gameOverUI;


    // Variable que almacenará la dirección.
    private float inputDireccionMovimiento;

    // Variable que almacena la velocidad del personaje.
    public float velocidadMovimiento = 6.5f;

    // Variable que almacena la fuerza del salto.
    public float fuerzaSalto = 13.0f;

    public float fuerzaMuerte;

    private float fuerzaLateral = 10f;

    public float fuerzaDeslizamiento = 0.2f;

    // Variable que almacena el radio para comprobar si dentro de dicho radio el personaje colisióna con algún objeto tipo suelo.
    private float radioSuelo = 0.06f;

    // Variable que almacena el radio para comprobar si dentro de dicho radio el personaje colisióna con algún objeto tipo pared.
    private float radioPared = 0.02f;

    //Variable que almacena el cooldown que tendrá nuestro dash.
    public float dashEnfriamiento;

    //Variable que almacena la velocidad de nuestro dash.
    public float fuerzaDash = 30f;

    private float checkPointX;

    private float checkPointY;

 
    // Booleano para comprobar si el personaje mira a la izquierda o la derecha
    private bool miraDerecha = true;

    // Booleano para saber si el personaje esta caminando 
    private bool estaCaminando;

    // Booleano para saber si el personaje esta en el suelo
    private bool estaEnSuelo = true;

    private bool estaDeslizando;

    private bool vivo;
    
    public bool estaMuerto;


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
            checkPared();
            
        }
    }

    // FixedUpdate es llamada ...
    private void FixedUpdate() {
        if(vivo == true){
            AplicarMovimiento();
            checkSuelo();
            Dash();
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

    public void checkSuelo(){
        estaEnSuelo = Physics2D.OverlapCircle(suelo.position, radioSuelo, mascaraSuelo);
    }

    public void checkPared(){
        if(Physics2D.OverlapCircle(pared.position, radioPared, mascaraPared) 
            && Mathf.Abs(inputDireccionMovimiento) > 0 && rb.velocity.y < 0 && !estaEnSuelo){
                estaDeslizando = true;
                Vector2 v = rb.velocity;
                v.y = -fuerzaDeslizamiento;
                rb.velocity = v;
        }
        else{
            estaDeslizando = false;
        }
    }

    //Función que nos permitirá realizar un dash.
    private void Dash(){

        dashEnfriamiento -= Time.deltaTime;

        if(Input.GetKey("e") && dashEnfriamiento <=0 && estaEnSuelo == false){
            GameObject objetoDash;
            objetoDash = Instantiate(efectoDash, transform.position, transform.rotation);

            if(miraDerecha){
                rb.AddForce(Vector2.right * fuerzaDash, ForceMode2D.Impulse);
            }
            else{
                rb.AddForce(Vector2.left * fuerzaDash, ForceMode2D.Impulse);
            }

            dashEnfriamiento = 1.2f;
            Destroy(objetoDash,1);
        }        
    }

    // Función que nos permitirá actualizar las animaciones del personaje
    private void actualizarAnimaciones(){
        anim.SetBool("isWalking", estaCaminando);
        anim.SetBool("isSliding", estaDeslizando);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("spikes") || other.transform.CompareTag("caida")){
            JugadorMuerto();
        }

        if(other.transform.CompareTag("PlataformaMov")){
            transform.parent = other.transform;
        }

    }

    private void OnCollisionExit2D(Collision2D other){
        if(other.transform.CompareTag("PlataformaMov")){
            transform.parent = null;
        }
    }

    public void CheckPointAlcanzado(float x, float y){

        PlayerPrefs.SetFloat("checkPointX", x);
        PlayerPrefs.SetFloat("checkPointX", y);

        spawn.position = new Vector2(x,y);
        
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

        gameOverUI.SetActive(true);
        
        StartCoroutine("RespawnJugador");
    }

    // Resetearemos las variables y cargaremos de nuevo la escena.
    IEnumerator RespawnJugador(){
        yield return new WaitForSeconds(2f);
        estaMuerto = false;
        anim.SetBool("death", estaMuerto);

        colliderJugador.enabled = true;
        foreach (GameObject obj in objetos)
            obj.SetActive(true);

        rb.gravityScale = 4f;

        gameOverUI.SetActive(false);

        yield return new WaitForSeconds(0.01f);
        vivo = true;

        if(!miraDerecha){
            CambiarDireccion();
        }
        
        transform.position = (new Vector2(spawn.position.x, spawn.position.y));
        Instantiate(spawnPrefab,spawn.position, spawn.rotation);
    }

}
