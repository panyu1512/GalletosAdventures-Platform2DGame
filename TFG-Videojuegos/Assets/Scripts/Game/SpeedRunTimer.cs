using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SpeedRunTimer : MonoBehaviour
{
    public static SpeedRunTimer instanciar;

    public Text cronometro;

    private TimeSpan tiempoCronometro;

    private bool cronometroBool;

    private float tiempoTranscurrido;
    // Start is called before the first frame update
    void Awake()
    {
        instanciar = this;
    }

    // Update is called once per frame
    void Start()
    {
        cronometro.text = "Time: 00:00:00";
        cronometroBool = false;

        //Iniciar cronometro modo SpeedRun
        IniciarCronometro();
    }

    public void IniciarCronometro(){
        cronometroBool = true;
        tiempoTranscurrido = 0f;

        StartCoroutine(actualizacionTiempo());
    }

    public void pararCronometro(){
        cronometroBool = false;

    }

    private IEnumerator actualizacionTiempo(){
        while(cronometroBool){
            tiempoTranscurrido += Time.deltaTime;
            tiempoCronometro = TimeSpan.FromSeconds(tiempoTranscurrido);
            string tiempoCrono = "Time: " + tiempoCronometro.ToString("mm':'ss':'ff");
            cronometro.text = tiempoCrono;

            yield return null;
        }
    }
}
