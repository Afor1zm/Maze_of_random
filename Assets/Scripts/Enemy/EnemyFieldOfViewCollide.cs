using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfViewCollide : MonoBehaviour
{
    private PlayerEvents playerEvents;

    private void Start()
    {        
        playerEvents = GetComponentInParent<PlayerEvents>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == other.gameObject.CompareTag("Player"))
        {
            playerEvents.OnDetected(other.gameObject.transform.position);                                 
        }
    }    
}
