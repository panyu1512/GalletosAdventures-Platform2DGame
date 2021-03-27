using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMov : MonoBehaviour
{
    // Variable que almacena el objeto plataforma
    public GameObject obj;

    // Variable que almacena el punto de inicio del movimiento de la plataforma
    public Transform puntoInicio;
    // Variable que almacena el punto final del movimiento de la plataforma
    public Transform puntoFinal;

    // Variable que almacena la velocidad con la que se movera la plataforma
    public float velocidad;

    // Variable que almacena la direccion en la que se moverá la plataforma
    private Vector3 direccionMov;

    // Start is called before the first frame update
    void Start()
    {
        direccionMov = puntoFinal.position;
    }

    // Update is called once per frame
    void Update()
    {
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, direccionMov, velocidad * Time.deltaTime);

        if(obj.transform.position == puntoFinal.position){
            direccionMov = puntoInicio.position;
        }

        if(obj.transform.position == puntoInicio.position){
            direccionMov = puntoFinal.position;
        }
    }

}
