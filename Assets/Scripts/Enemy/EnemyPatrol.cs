using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{   
    private NavMeshAgent navigationAgent;
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 patrolPosition;
    [SerializeField] private Vector3 bufferPosition;    
    private const float speed = 1f;
    public bool FollowingPlayer;


    private void Start()
    {
        FollowingPlayer = false;
        navigationAgent = GetComponent<NavMeshAgent>();
        navigationAgent.speed = speed;        
        startPosition = transform.position;        
        bufferPosition = patrolPosition;       
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

    public void SetFollowingPlayer(bool OnFollow)
    {
        FollowingPlayer = OnFollow;
    }
}
