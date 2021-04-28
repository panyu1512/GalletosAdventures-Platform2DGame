using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformInteractive : MonoBehaviour
{
    // Variable que almacena la animación
    public Animator animator;

    public BoxCollider2D coll;

    public GameObject palanca;




    private void Update() {

        if(palanca.GetComponent<Lever>().On == true){
            animator.Play("PlatformInteractiveOn");
            coll.enabled = true;
        }
    }
}
