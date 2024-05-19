using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DontDestroy : MonoBehaviour
{
    public GameObject parentGameObject;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    public void OnPlayerJoined(GameObject player)
    {
        player.transform.SetParent(parentGameObject.transform);
    }
}
