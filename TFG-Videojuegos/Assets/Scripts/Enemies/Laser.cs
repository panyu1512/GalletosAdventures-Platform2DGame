using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private float tiempoSpawn;
    public float inicioTiempoSpawn;
    public GameObject laser;
    public Transform lugarSpawn;
    public AudioSource sonidoLaser;


    // Update is called once per frame
    private void Update()
    {
        if(tiempoSpawn <= 0){
            Instantiate(laser, lugarSpawn.position, lugarSpawn.rotation);
            sonidoLaser.Play();
            tiempoSpawn = inicioTiempoSpawn;
        }else{
            tiempoSpawn -= Time.deltaTime;
        }
    }

}
