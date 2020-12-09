using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFieldOfViewCollide : MonoBehaviour
{
    private EnemyFollowPlayer folowPlayer;
    private EnemyPatrol patrol;

    private void Start()
    {
        folowPlayer = GetComponentInParent<EnemyFollowPlayer>();
        patrol = GetComponentInParent<EnemyPatrol>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == other.gameObject.CompareTag("Player"))
        {            
            patrol.FollowingPlayer = true;
            folowPlayer.following = true;
            folowPlayer.SetPlayerPosition(other.gameObject.transform.position);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == other.gameObject.CompareTag("Player"))
        {            
            patrol.FollowingPlayer = false;            
            folowPlayer.SetPlayerPosition(other.gameObject.transform.position);
        }
    }
}
