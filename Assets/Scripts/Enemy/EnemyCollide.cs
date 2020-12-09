using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    private PlayerEvents playerEvents;
    private void Start()
    {
        playerEvents = GetComponent<EnemyListener>().PlayerEvents;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == collision.gameObject.CompareTag("Player"))
        {            
            playerEvents.OnGameOver();
        }
    }    
}
