using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollide : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"YouLose");
        }
    }    
}
