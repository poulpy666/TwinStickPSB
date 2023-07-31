using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class EnnemiesScript : MonoBehaviour
{
   public enum EnnemiState
    {
        Chase,
        Attack
    }
    [SerializeField] private EnnemiState currentState;
    private void Chase()
    {

    }
    private void Attack()
    {
        
    }
    private void CheckForState()
    {

    }
    private void Update()
    {
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

