using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPlayer : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] spawnPoints;

    // Update is called once per frame
    void Update()
    {
        //              ####################
        //getting the players & spawnpoints should be moved to a loop that runs once in start to save memory
        //              ####################

        players = GameObject.FindGameObjectsWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for(int i = 0; i < players.Length; i++)
        {
            if((players[i].transform.position.y < -10) || (players[i].transform.position.y > 15))
                ResetPlayerPosition(players[i], i);
        }
    }

    void ResetPlayerPosition(GameObject player, int i)
    //Takes a specific player as well as their index.
    //Disables their character controller in order to update their position and then re-enables the controller.
    {
        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        player.transform.position = spawnPoints[i].transform.position;
        charController.enabled = true;
    }
}