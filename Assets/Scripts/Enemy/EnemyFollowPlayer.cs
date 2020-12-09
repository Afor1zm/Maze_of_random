using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowPlayer : MonoBehaviour
{
    //public GameObject player;
    public Vector3 currentplayerPosition;
    private NavMeshAgent navigationAgent;
    private const float speed = 1f;
    public bool following;
   
    private void Start()
    {
        navigationAgent = GetComponent<NavMeshAgent>();       
        navigationAgent.speed = speed;        
    }
    
    void FixedUpdate()
    {
        if (following)
        {
            if (currentplayerPosition != new Vector3(0, 0, 0))
            {
                if (transform.position != currentplayerPosition)
                {
                    //playerPosition = player.transform.position;
                    navigationAgent.SetDestination(currentplayerPosition);
                }
                else
                {
                    Debug.Log($"Im on position");
                    following = false;
                }
            }
        }
        
    }

    public void SetPlayerPosition(Vector3 playerPosition)
    {
        currentplayerPosition = playerPosition;
        Debug.Log($"Start follow");
    }
}
