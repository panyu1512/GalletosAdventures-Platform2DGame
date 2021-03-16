using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraFollowPlayer : MonoBehaviour
{
    // Variable que almacena el objeto player
    public GameObject player;

    void FixedUpdate() {
        
        // posicionX guarda la posición horizontal del jugador
        float posicionX = player.transform.position.x;

        // posicionY guarda la posición vertical del jugador
        float posicionY = player.transform.position.y;

        // Asignamos a la posición de la cámara la posicionX y la posicionY del jugador
        transform.position = new Vector3(posicionX, posicionY, transform.position.z);
    }

}
