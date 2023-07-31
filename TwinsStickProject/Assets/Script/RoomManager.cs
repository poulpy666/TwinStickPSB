using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    [SerializeField] private GameObject[] ennemies;
    [SerializeField] private GameObject[] doors;
    [SerializeField] private bool[] playerIsInTeRoom;

    private void AllPlayerRoom()
    {
        foreach (GameObject door in doors)
        {
            door.SetActive(true);
        }
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
