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
    private PlayerEvents publicPlayerEvents;
    private Renderer enemyRenderer;
   
    private void Start()
    {
        playerEvents = GetComponent<PlayerEvents>();
        publicPlayerEvents = GetComponent<EnemyListener>().PlayerEvents;
        navigationAgent = GetComponent<NavMeshAgent>();
        navigationAgent.speed = speed;
        enemyRenderer = GetComponent<Renderer>();
        publicPlayerEvents.OnNoise += SetPlayerPosition;
        publicPlayerEvents.OnSectorChecked += StopFollowing;
        playerEvents.OnDetected += SetPlayerPosition;
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
                    publicPlayerEvents.OnSectorChecked();
                }
            }
        }        
    }

    private void SetPlayerPosition(Vector3 playerPosition)
    {
        enemyRenderer.material.color = new Color32(255, 0, 107, 255);
        following = true;
        currentplayerPosition = playerPosition;        
    }

    private void StopFollowing()
    {
        following = false;
        enemyRenderer.material.color = new Color32(255, 255, 255, 255);
    }
}
