using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExiitTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {        
        if (other.gameObject == other.CompareTag("Player"))
        {
            Debug.Log($"YouWin");
        }
    }
}
