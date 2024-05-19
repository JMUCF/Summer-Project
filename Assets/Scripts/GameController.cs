using UnityEngine;
using UnityEngine.InputSystem;

public class GameController : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to the player prefab

    private void Start()
    {
        foreach (var player in PlayerManager.Instance.players)
        {
            Debug.Log($"Player ID: {player.playerID}, Controller Type: {player.playerDevice}");
            // Instantiate player prefab for each player
            InstantiatePlayer(player);
        }
    }

    // Method to instantiate player prefab for a single player
    private void InstantiatePlayer(PlayerManager.PlayerData player)
    {
        // Instantiate the player prefab
        GameObject instantiatedPlayer = Instantiate(playerPrefab, new Vector3(10, 10, 10), Quaternion.identity);

        
        // Optionally, you can set properties of the instantiated player based on player data
        // For example:
        PlayerInput playerInput = instantiatedPlayer.gameObject.GetComponent<PlayerInput>();
        playerInput.SwitchCurrentControlScheme(player.controlScheme, player.playerDevice);
    }
}
