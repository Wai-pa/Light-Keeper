using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float climbingSpeed = 5f;
    private Vector3 moveVector;
    private Vector2 inputVector;

    [Header("Jump")]
    [SerializeField] private float jumpSpeed = 8f;
    [SerializeField] private float currentVerticalSpeed;
    [SerializeField] private float gravity = 9.8f;
    private bool isJumping;
    private bool torchIsOn = true;

    [Header("Miscellaneous")]
    [SerializeField] private bool isPaused = false;
    [SerializeField] private bool isInteracted = false;
    [SerializeField] private float forceToPushObj = 0.05f;
    private List<GameObject> ladders;

    [Header("Instances")]
    private GameManager gameManager;
    private SoundManager soundManager;
    private PauseMenu pauseMenu;
    private CharacterController controller;
    private TorchController torchController;

    void Start()
    {
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        pauseMenu = PauseMenu.instance;

        controller = GetComponent<CharacterController>();
        torchController = GetComponentInChildren<TorchController>();

        ladders = new List<GameObject>();
    }

    void Update()
    {
        Movement();
        ToggleTorch();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        isPaused = context.performed;
        pauseMenu.Pause(isPaused);
    }

    public void OnInteraction(InputAction.CallbackContext context)
    {
        isInteracted = context.performed;
    }

    void Movement()
    {
        if (controller.isGrounded)
        {
            currentVerticalSpeed = 0;
            moveVector.x = inputVector.x * movementSpeed;

            if (isJumping) { currentVerticalSpeed = jumpSpeed; }
        }
        else { moveVector.x = inputVector.x * movementSpeed / 2; }

        isJumping = false;

        if (ladders.Any())
        {
            currentVerticalSpeed = inputVector.y * climbingSpeed;
        }
        else
        {
            currentVerticalSpeed -= gravity * Time.deltaTime;
        }

        moveVector.y = currentVerticalSpeed;
        controller.Move(moveVector * Time.deltaTime);
    }

    void ToggleTorch()
    {
        if (!Input.GetButtonDown("Torch"))
        {
            return;
        }

        torchIsOn = !torchIsOn;
        torchController.gameObject.SetActive(torchIsOn);
    }

    public void EnterLadder(GameObject ladder)
    {
        ladders.Add(ladder);
    }

    public void LeaveLadder(GameObject ladder)
    {
        ladders.Remove(ladder);
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (isInteracted)
        {
            Rigidbody rigidbody = hit.collider.attachedRigidbody;
            if (rigidbody != null)
            {
                Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
                forceDirection.y = 0;
                forceDirection.z = 0;
                forceDirection.Normalize();
                rigidbody.AddForceAtPosition(forceDirection * forceToPushObj, transform.position, ForceMode.Impulse);
            }
        }
    }
}
