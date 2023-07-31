using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ennemies;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private bool[] playerIsInTeRoom;
    [SerializeField] private float Spawn = 5f;


    private void AllPlayerRoom()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
        StartCoroutine(SpawnCD());
              
    }
    IEnumerator SpawnCD()
    {
        yield return new WaitForSeconds(Spawn);

        foreach (GameObject Ennemy in ennemies)
        {

            Ennemy.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out InputManager inputManager))
        {
            playerIsInTeRoom[inputManager.noOfPlayer - 1] = true;
            if (playerIsInTeRoom[0]&& playerIsInTeRoom[1])
            {
                AllPlayerRoom();
            } 
        }
    }
}
