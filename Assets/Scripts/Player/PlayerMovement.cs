using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 moveDirection;
    private const int speed = 1;
    
    void FixedUpdate()
    {
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        moveDirection = new Vector3(xDirection, 0, yDirection);        
        transform.position += moveDirection * speed * Time.fixedDeltaTime;
    }

    public Vector3 GetMovementDirection()
    {
        return moveDirection;
    }
}
