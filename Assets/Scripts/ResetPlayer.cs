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
            if((players[i].transform.position.y < -10) || (players[i].transform.position.y > 15))
                ResetPlayerPosition(players[i], i);
        }
    }

    
    /// JUST HAD AN EPIPHANY ITS PROBABLY NOT THE PLAYER INPUT COMPONENT OVERRIDING THE TRANSFORM POSITION, IT'S PROBABLY THE CHARACTER CONTROLLER. LOOK INTO TEMPORARILY DISABLING THAT AND MOVING THE POSITION AS OPPOSED TO TURNING OFF THE WHOLE CHARACTER OR DEACTIVATING THE PLAYER INPUT COMPONENT

    //https://docs.unity3d.com/ScriptReference/Component-transform.html


    void ResetPlayerPosition(GameObject player, int i)
    {
        Debug.Log("in reset players position + " + player + " " + i);

        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        playerInput.DeactivateInput();
        player.transform.position = spawnPoints[i].transform.position; //this is almost working but not quite. I think the deactivate and activate is working but the position is not being changed. Can maybe do the setactive but then need to pull playermanager stats to reassign them after active swap
        playerInput.ActivateInput();

        /*  this section does not work
        PlayerManager.PlayerData playerManager;
        int playerID;
        string controlScheme;
        PlayerInput playerInput = player.GetComponent<PlayerInput>();
        var devices = playerInput.devices;
        InputDevice playerDevice = null;
        foreach (var device in devices)
        {
            // Print out the device name and other relevant information
            playerDevice = device;
        }
        playerID = playerInput.playerIndex;
        controlScheme = playerInput.currentControlScheme;
        player.SetActive(false);
        player.transform.position = spawnPoints[i].transform.position;
        player.SetActive(true);
        
        playerInput.SwitchCurrentControlScheme(playerManager.controlScheme, playerManager.playerDevice);
        //Debug.Log(spawnPoints[i].transform.position);*/
    }
}