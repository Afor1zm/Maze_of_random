using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private const int noise = 3;
    private const float silence = 2f;
    [SerializeField] private float currentNoise = 0f;
    private PlayerMovement currentMovement;
    
    void Start()
    {       
        currentMovement = GetComponent<PlayerMovement>();
    }
    
    void FixedUpdate()
    {
        if (currentMovement.GetMovementDirection() != new Vector3(0f, 0f, 0f))
        {
            currentNoise += noise * Time.fixedDeltaTime;
        }
        else
        {
            if (currentNoise > 0)
            {
                currentNoise -= silence * Time.fixedDeltaTime;
            }
        }
        if (currentNoise >= 10)
        {
            //gameEvents.OnNoise();
        }
    }

    public Transform GetPlayerPosition()
    {
        return transform;
    }
}
