using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyListener : MonoBehaviour
{
    public PlayerEvents PlayerEvents;
    private Vector3 Pos;

    private void Start()
    {        
        PlayerEvents.OnNoise += SomeAction;
    }

    private void SomeAction(Vector3 position)
    {
        Pos = position;              
    }
}
