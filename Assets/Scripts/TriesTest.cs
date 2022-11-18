using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriesTest : MonoBehaviour
{
    [SerializeField] UIGameScript uIGameScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uIGameScript.Tries += 10;
            uIGameScript.UpdateTries();//actualizandoWT Y TR
            Destroy(gameObject, 0.5f);
        }
    }
}
