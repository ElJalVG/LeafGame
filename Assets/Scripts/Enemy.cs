using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float velocidad;
    private float tiempoEspera;
    public float inicioTiempoEspera;
    public Transform movePunto;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera=inicioTiempoEspera;
        movePunto.position=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));

    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }
    public void MoverEnemigo()
    {
        transform.position=Vector2.MoveTowards(transform.position,movePunto.position,velocidad*Time.deltaTime);
        if(Vector2.Distance(transform.position,movePunto.position)<0.2f)
        {
            if(tiempoEspera<=0)
            {
                movePunto.position=new Vector2(Random.Range(minX,maxX),Random.Range(minY,maxY));
                tiempoEspera=inicioTiempoEspera;
            }
            else
            {
                tiempoEspera-=Time.deltaTime;
            }
        }
    }
}
