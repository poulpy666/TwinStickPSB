using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerController pc;
    [SerializeField] public int noOfPlayer;
    [SerializeField] private GameObject ball;
    public GameObject tempBull;
    private Vector2 direction;
    private void GetDirection()
    {
        direction.x = Input.GetAxis("HorizontalP"+noOfPlayer);
        direction.y = Input.GetAxis("VerticalP" + noOfPlayer);
    }
   
    public void Fire()
    {
        if (noOfPlayer == 1 && Input.GetKeyDown(KeyCode.E)) 
        {
            tempBull= Instantiate(ball,transform.position+transform.forward*3f,Quaternion.identity);
            tempBull.GetComponent<Balle>().Movem(transform.forward);
        }
        else if (noOfPlayer == 2 && Input.GetKeyDown(KeyCode.O)) 
        {
            tempBull=Instantiate(ball, transform.position + transform.forward * 3f, Quaternion.identity);
            tempBull.GetComponent<Balle>().Movem(transform.forward);
        }
    }
   
    // Update is called once per frame
    void Update()
    {
        GetDirection();
        pc.Move(direction);
        Fire();
        pc.GetRotation();
    }
}
