using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{
    public float velocidad = 2f;
    
    public float tiempoVida = 2;

    void Start(){
        Destroy(gameObject, tiempoVida);
    }

    void Update() {
        movimientoBala();
    }

    public void movimientoBala(){
        transform.Translate(Vector2.down * velocidad * Time.deltaTime);
    }
  

}
