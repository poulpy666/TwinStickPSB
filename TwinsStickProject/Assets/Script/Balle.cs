using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Balle : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float speed;
    private Vector3 direction;
    public void Movem(Vector3 direction)
    {
        this.direction = direction;
    }
    public void FixedUpdate() 
    {
        rb.velocity=new Vector3 (direction.x,0, direction.z)*speed;

    }
    
}
