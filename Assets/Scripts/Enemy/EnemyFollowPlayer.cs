using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    public bool following;
    public Vector3 currentplayerPosition;
    private NavMeshAgent navigationAgent;
    private const float speed = 1f;    
    private PlayerEvents playerEvents;
    private Renderer enemyRenderer;
   
    private void Start()
    {
        playerEvents = GetComponent<EnemyListener>().PlayerEvents;
        navigationAgent = GetComponent<NavMeshAgent>();       
        navigationAgent.speed = speed;
        enemyRenderer = GetComponent<Renderer>();
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
                    enemyRenderer.material.color = new Color32(255, 255, 255, 255);
                }
            }
        }
        
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        enemyRenderer.material.color = new Color32(255, 0, 107, 255);
        following = true;
        currentplayerPosition = playerPosition;        
    }
}
