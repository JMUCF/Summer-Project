using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public List<GameObject> playerList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach (var players in PlayerManager.Instance.players)
        {
            GameObject player = GameObject.FindWithTag("Player");
            playerList.Add(player);
        }
    }
}