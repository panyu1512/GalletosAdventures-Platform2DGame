using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy3 : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;

    public Transform[] spotsMovimiento;

    private Vector2 posicionActual;

    public float velocidad = 0.5f;

    public float inicioTiempoEspera = 2f;

    private float tiempoEspera;

    private int i = 0;



    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera = inicioTiempoEspera;
    }

    // Update is called once per frame
    void Update()
    {
        movimientoEnemigo();
    }

    void movimientoEnemigo() {

        transform.position = Vector2.MoveTowards(transform.position, spotsMovimiento[i].transform.position, velocidad * Time.deltaTime);

        if(Vector2.Distance(transform.position, spotsMovimiento[i].transform.position) < 0.1f){
            if(tiempoEspera <= 0){
                if(spotsMovimiento[i] != spotsMovimiento[spotsMovimiento.Length-1]){
                    i++;
                }
                else{
                    i = 0;
                }
                tiempoEspera = inicioTiempoEspera;
            }
            else{
                tiempoEspera -= Time.deltaTime;
            }
        }
    }

}
