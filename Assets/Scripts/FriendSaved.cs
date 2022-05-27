using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSaved : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            LeaderBoard.Instance.SendLeaderboard(10);
            Destroy(gameObject,0.5f);
        
        }
    }
}
