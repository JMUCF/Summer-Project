using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    #region Variables
    [SerializeField] private float playerSpeed = 4.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    public GameObject projectilePrefab;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    private Vector2 movementInput = Vector2.zero;
    private Vector2 lookInput = Vector2.zero;
    private bool jumped = false;
    #endregion

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context) //only works for controller atm. will probably need some distinction for what code is ran based on what the individual player's control scheme is
    {
        lookInput = context.ReadValue<Vector2>();

        if (lookInput.sqrMagnitude == 0) return; //don't reset rotation on no input
        var targetAngle = Mathf.Atan2(lookInput.x, lookInput.y) * Mathf.Rad2Deg; //turn joystick angle position into rotation angle
        transform.rotation = Quaternion.Euler(0.0f, targetAngle-90, 0.0f); //change angle
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumped = context.action.triggered;
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Vector3 spawnPosition = transform.position; //currently spawns on player position. Using .forward spawns it to the right of the player.

        GameObject thrownObject = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(movementInput.x, 0, movementInput.y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (jumped && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}