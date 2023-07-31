using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor;
using UnityEngine;

public class EnnemiesScript : PlayerController
{
    private bool playerInSight;
    private Transform player;
    [SerializeField] private GameObject ball;
    private GameObject tempBull;
    private float onFaya = 1f;
    

    public enum EnnemiState
    {
        Chase,
        Attack
    }
    [SerializeField] private EnnemiState currentState;

    public override void Move(Vector2 moveTo)
    {
       base.Move(moveTo);
    }
    private void Chase()
    {
       
            transform.LookAt(player.transform.position);
            rb.velocity = transform.forward*speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>() != null)
        {
            player = other.transform;
            playerInSight = true;

        }
    }
    private void Attack()
    {
        StartCoroutine(FayaCD());
         IEnumerator FayaCD()
        {
            tempBull = Instantiate(ball, transform.position + transform.forward * 3f, Quaternion.identity);
            tempBull.GetComponent<Balle>().Movem(transform.forward);
            yield return new WaitForSeconds(onFaya);
            yield return null;
        }
    }
    private void CheckForState()
    {
        if ((Vector3.Distance(transform.position, player.position) <= 10))
        {
            currentState= EnnemiState.Attack;
        }
        else if ((Vector3.Distance(transform.position, player.position) >= 10))
        {
            currentState= EnnemiState.Chase;
        }
    }
    private void FixedUpdate()
    {
        if (!playerInSight) return;
        CheckForState();

        switch(currentState)
        {
            case EnnemiState.Chase:
            Chase();
            break;
            case EnnemiState.Attack:
            Attack(); 
            break;
        }
    }
}

