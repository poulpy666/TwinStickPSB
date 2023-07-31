using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemiesScript : MonoBehaviour
{
    private bool playerInSight;
    private Transform player;
    [SerializeField] private Rigidbody rb;
    public  void Movement()
    {
        if ((playerInSight) && (Vector3.Distance(transform.position, player.position) > 5))
        {
            transform.LookAt(player.transform.position);
            rb.velocity = transform.forward;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)

            player = other.transform;
            playerInSight = true;
        
    }
    private void OnTriggerExit(Collider other)
    {
        
    }
}
