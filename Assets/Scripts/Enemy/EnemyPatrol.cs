using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{   
    private NavMeshAgent navigationAgent;
    private Vector3 startPosition;
    private Vector3 patrolPosition;
    private Vector3 bufferPosition;    
    private const float speed = 1f;
    private bool FollowingPlayer;
    private PlayerEvents playerEvents;
    private PlayerEvents publicPlayerEvents;

    private void Start()
    {
        FollowingPlayer = false;
        navigationAgent = GetComponent<NavMeshAgent>();
        playerEvents = GetComponent<PlayerEvents>();
        publicPlayerEvents = GetComponent<EnemyListener>().PlayerEvents;
        navigationAgent.speed = speed;        
        startPosition = transform.position;        
        bufferPosition = patrolPosition;
        playerEvents.OnDetected += StopPatrol;
        playerEvents.OnNoise += StopPatrol;
        playerEvents.OnSectorChecked += ContinuePatrol;
        publicPlayerEvents.OnSectorChecked += ContinuePatrol;
    }

    private void FixedUpdate()
    {
        if (!FollowingPlayer)
        {
            if (transform.position != patrolPosition)
            {
                navigationAgent.SetDestination(patrolPosition);
            }
            else
            {
                if (patrolPosition == startPosition)
                {
                    patrolPosition = bufferPosition;
                }
                else
                {
                    patrolPosition = startPosition;
                }
            }
        }
    }

    public void SetPatrolCell(Vector3 patrolCell)
    {
        patrolPosition = new Vector3(patrolCell.x, -0.2659531f, patrolCell.z);
    }
    
    private void StopPatrol(Vector3 vector)
    {
        FollowingPlayer = true;
    }

    private void ContinuePatrol()
    {
        FollowingPlayer = false;
    }
}
