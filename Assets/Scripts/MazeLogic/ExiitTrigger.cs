using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExiitTrigger : MonoBehaviour
{
    [SerializeField] private PlayerEvents playerEvents;
    
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject == other.CompareTag("Player"))
        {
            playerEvents.OnWin();
            Debug.Log($"YouWin");
        }
    }
}
