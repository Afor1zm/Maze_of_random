using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{   
    public Vector3 currentplayerPosition;
    private NavMeshAgent navigationAgent;
    private const float speed = 1f;
    public bool following;
    private PlayerEvents playerEvents;
   
    private void Start()
    {
        playerEvents = GetComponent<EnemyListener>().PlayerEvents;
        navigationAgent = GetComponent<NavMeshAgent>();       
        navigationAgent.speed = speed;
        playerEvents.OnNoise += SetPlayerPosition;
    }
    
    void FixedUpdate()
    {
        if (following)
        {
            if (currentplayerPosition != new Vector3(0, 0, 0))
            {
                if (transform.position != currentplayerPosition)
                {                    
                    navigationAgent.SetDestination(currentplayerPosition);
                }
                else
                {                    
                    following = false;
                }
            }
        }
        
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        following = true;
        currentplayerPosition = playerPosition;        
    }
}
