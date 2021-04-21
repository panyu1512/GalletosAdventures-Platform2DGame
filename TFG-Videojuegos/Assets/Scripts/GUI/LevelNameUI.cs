using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Text))]
public class LevelNameUI : MonoBehaviour
{
    public GameObject nombreNivelUI;
    private Text nombreNivel;
    private Scene escenaActual;
    private float contadorSegundos=0;
    private int num;

    // Start is called before the first frame update
    void Start(){
        escenaActual = SceneManager.GetActiveScene();
        nombreNivel = GetComponent<Text>();
        num = 0;
    }
    
    // Update is called once per frame
    void Update()
    {   
        contadorSegundos += Time.deltaTime;

        if(escenaActual.buildIndex >= 3){
            nombreNivel.text = "Nivel " + (escenaActual.buildIndex-2);
        }
        else{
            nombreNivel.text = "Tutorial";
        }

        if(contadorSegundos > 3.5){
            nombreNivelUI.SetActive(false);
        }
    }
}
