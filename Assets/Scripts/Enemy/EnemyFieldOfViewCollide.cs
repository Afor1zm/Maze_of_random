using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfViewCollide : MonoBehaviour
{
    private EnemyFollowPlayer folowPlayer;
    private EnemyPatrol patrol;
    private PlayerEvents playerEvents;

    private void Start()
    {
        folowPlayer = GetComponentInParent<EnemyFollowPlayer>();
        patrol = GetComponentInParent<EnemyPatrol>();
        playerEvents = GetComponentInParent<PlayerEvents>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == other.gameObject.CompareTag("Player"))
        {
            playerEvents.OnDetected(other.gameObject.transform.position);
            patrol.FollowingPlayer = true;
            folowPlayer.following = true;            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == other.gameObject.CompareTag("Player"))
        {            
            patrol.FollowingPlayer = false;
        }
    }
}
