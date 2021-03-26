using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    // Variable que almacenará el componente Rigidbody2D
    private Rigidbody2D rb;
    // Variable que almacena la velocidad del personaje
    public float velocidadDesplazamiento = 4f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Función que aplicará la fuerza lateral de la plataforma
    private void AplicarMovimiento(){
        rb.velocity = new Vector2(velocidadDesplazamiento, rb.velocity.y);
    }
}
