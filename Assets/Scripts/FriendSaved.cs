using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSaved : MonoBehaviour
{
    [SerializeField] UIGameScript uIGameScript;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            uIGameScript.Water += 10;
            uIGameScript.UpdateWater();
            Destroy(gameObject, 0.5f);
        }
    }
}
