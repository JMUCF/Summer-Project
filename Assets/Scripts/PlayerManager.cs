using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [System.Serializable]
    public class PlayerData
    {
        public int playerID;
        public string controlScheme;
        public InputDevice playerDevice;
    }

    public List<PlayerData> players = new List<PlayerData>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddPlayer(int playerID, string controlScheme, InputDevice playerDevice)
    {
        players.Add(new PlayerData { playerID = playerID, controlScheme = controlScheme, playerDevice = playerDevice});
    }

    public void RemoveAllPlayers()
    {
        players.Clear();
    }
}
