using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrullaje : MonoBehaviour
{
    public float velocidad;
    private float tiempoEspera;
    public float inicioTiempoEspera;
    public Transform[] movePuntos;
    private int randomPunto;
    public Animator anim;
    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera=inicioTiempoEspera;
        randomPunto=Random.Range(0,movePuntos.Length);
        sprite=GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }
    public void MoverEnemigo()
    {
        Vector3 dir=movePuntos[randomPunto].position-transform.position;
        bool flipX=dir.x<0;
        sprite.flipX=flipX;
        transform.position=Vector2.MoveTowards(transform.position,movePuntos[randomPunto].position,velocidad*Time.deltaTime);
        if(Vector2.Distance(transform.position,movePuntos[randomPunto].position)<0.2f)
        {
            anim.SetBool("CaminarEnemy",false);
            if(tiempoEspera<=0)
            {
                randomPunto=Random.Range(0,movePuntos.Length);
                tiempoEspera=inicioTiempoEspera;
            }
            else
            {
                
                tiempoEspera-=Time.deltaTime;
            }
        } else{
            anim.SetBool("CaminarEnemy",true);
        }
    }
}
