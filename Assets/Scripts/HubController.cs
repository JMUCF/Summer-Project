using UnityEngine;
using UnityEngine.InputSystem;

public class HubController : MonoBehaviour
{
    private PlayerInputManager playerInputManager;
    private int counter = 1;

    private void Awake()
    {
        playerInputManager = FindObjectOfType<PlayerInputManager>();
    }

    private void OnDestroy()
    {
        // Unsubscribe to avoid potential memory leaks
        if (playerInputManager != null)
        {
            //playerInputManager.onPlayerJoined -= OnPlayerJoined;
        }
    }

    public void OnTriggerEnter(Collider collision)
    {
        Debug.Log("in trigger");

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerChecked playerChecked = collision.gameObject.GetComponent<PlayerChecked>();
            if (!playerChecked.isChecked)
            {
                PlayerInput playerInput = collision.gameObject.GetComponent<PlayerInput>();

                var devices = playerInput.devices;
                InputDevice playerDevice = null;
                foreach (var device in devices)
                {
                    // Print out the device name and other relevant information
                    playerDevice = device;
                }

                int playerID = playerInput.playerIndex;
                string controlScheme = playerInput.currentControlScheme;
                playerChecked.isChecked = true;

                PlayerManager.Instance.AddPlayer(playerID, controlScheme, playerDevice);
            }
            else
            {
                Debug.LogWarning("No PlayerInput component found on the collided object or player already joined.");
            }
        }
    }

    // Example method to start the game and load the next scene
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}
