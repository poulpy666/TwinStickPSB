using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector2 direction;
    [SerializeField] public Rigidbody rb;
    [SerializeField] public int speed;

public  virtual void Move(Vector2 moveTo)
    {
        direction = moveTo;
        rb.velocity = new Vector3 (direction.x*speed,0,direction.y*speed);
    }
    public void GetRotation()
    { 
        
        if (Vector2.zero != direction)
        {
            transform.LookAt(transform.position + new Vector3(direction.x, 0, direction.y));
        }
    }

}
