using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombHitBox : MonoBehaviour
{
    void Start()
    {
        StartCoroutine("SelfDestruct");
    }

    void OnTriggerEnter(Collider collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(KillPlayer(collision.gameObject));
        }
    }

    private IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(.25f);
        Destroy(this.gameObject);
    }

    //this does not work good. Should probably change a variable on the player that says is dead or something then have reset player be checking for that. Can maybe edit this so that resetplayerposition is called below, player is passed to it & the playerdata playerid int is passed as the index. Just dont have time rn but I think going the playerdata route is the better option of those two. This fix kinda works once in game, though

    private IEnumerator KillPlayer(GameObject player)
    {
        CharacterController charController = player.GetComponent<CharacterController>();
        charController.enabled = false;
        player.transform.position = new Vector3 (1000, 0, 0);
        yield return new WaitForSeconds(0f);
        charController.enabled = true;
    }
}
