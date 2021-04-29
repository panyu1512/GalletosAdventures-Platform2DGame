using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDamage : MonoBehaviour
{
    public BoxCollider2D coll;

    public Animator animator;

    public GameObject enemigo;

    public SpriteRenderer spriteRenderer;

    public GameObject particulaMuerte;

    public float fuerzaSalto = 2.5f;

    public int vidas = 2;


    private void OnCollisionEnter2D(Collision2D other) {
        if(other.transform.CompareTag("jugador")){
            other.gameObject.GetComponent<Rigidbody2D>().velocity = (Vector2.up * fuerzaSalto);
            DañoEnemigo();
            ComprobarVidaEnemigo();
        }
    }

    public void DañoEnemigo(){
        vidas --;
        animator.Play("EnemyHit");
    }

    public void MuerteEnemigo(){
        Destroy(gameObject);
    }

    public void RespawnEnemigo(){
        //Instantiate(enemigo);
    }

    public void ComprobarVidaEnemigo(){
        if(vidas == 0){
        
        spriteRenderer.enabled = false;
        particulaMuerte.SetActive(true);
        Invoke("MuerteEnemigo", 0.2f);      
        }

    }
}
