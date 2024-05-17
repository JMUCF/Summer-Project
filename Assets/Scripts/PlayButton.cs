using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Switch to the "TestScene"
            Debug.Log("test");
            SceneManager.LoadScene("TerrainTests");
        }
    }
}
