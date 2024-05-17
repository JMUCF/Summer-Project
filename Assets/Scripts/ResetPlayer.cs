using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ResetPlayer : MonoBehaviour
{
    public GameObject[] players;
    public GameObject[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        spawnPoints = GameObject.FindGameObjectsWithTag("SpawnPoint");

        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].transform.position.y < -10)
                ResetPlayerPosition(players[i], i);
        }
    }

    void ResetPlayerPosition(GameObject player, int i)
    {
        //Debug.Log(player.transform.position);
        player.SetActive(false);
        player.transform.position = spawnPoints[i].transform.position;
        player.SetActive(true);
        //Debug.Log(spawnPoints[i].transform.position);
    }
}