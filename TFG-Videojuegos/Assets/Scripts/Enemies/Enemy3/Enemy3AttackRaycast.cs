using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3AttackRaycast : MonoBehaviour
{

    public GameObject bala;

    public float distanciaRaycast;

    public float cooldownAtaque = 1.5f;
    private float actualCooldown;




    // Start is called before the first frame update
    void Start()
    {
        actualCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        actualCooldown -= Time.deltaTime; 
        Debug.DrawRay(transform.position, Vector2.down, Color.red);
    }

    void FixedUpdate(){
        RaycastHit2D hit2d = Physics2D.Raycast(transform.position, Vector2.down, distanciaRaycast);

        if(hit2d.collider != null){
            if(hit2d.collider.CompareTag("jugador")){
                if(actualCooldown < 0){
                    Invoke("lanzarBala", 0.5f);
                    actualCooldown = cooldownAtaque;
                }
            }
        }
    }

    void lanzarBala(){
        GameObject nuevaBala;

        nuevaBala = Instantiate(bala, transform.position, transform.rotation);
    }
}
