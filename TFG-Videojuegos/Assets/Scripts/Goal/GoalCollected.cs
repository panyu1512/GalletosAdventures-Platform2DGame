using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalCollected : MonoBehaviour
{

    private int siguienteEscena;

    private void Start() {
        siguienteEscena = SceneManager.GetActiveScene().buildIndex + 1;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            Destroy(gameObject, 2f);
        }    
    }

    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("jugador")){
            SceneManager.LoadScene(siguienteEscena);
        }
    }
}
