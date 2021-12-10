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
    [SerializeField] private bool isJumping;
    [SerializeField] private bool torchIsOn = false;
    [SerializeField] private bool isStanding = false;

    [Header("Effects")]
    [SerializeField] private AudioClip[] clips = null;

    [Header("Miscellaneous")]
    [SerializeField] private bool isPaused = false;
    public bool isPicked = false;
    public bool isDrop = false;
    [SerializeField] private float forceToPushObj = 0.05f;
    private List<GameObject> ladders;

    [Header("Instances")]
    private GameManager gameManager;
    private SoundManager soundManager;
    private PauseMenu pauseMenu;
    private CharacterController controller;
    private TorchController torchController;
    private PlayerInventory inventory;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;

    public GameObject torchOnGround;

    private GameObject tempObj;

    void Start()
    {
        gameManager = GameManager.instance;
        soundManager = SoundManager.instance;
        pauseMenu = PauseMenu.instance;

        controller = GetComponent<CharacterController>();
        torchController = GetComponentInChildren<TorchController>();
        inventory = GetComponent<PlayerInventory>();

        if (torchIsOn)
        {
            inventory.Add(PlayerInventory.InvetoryItem.Torch);
        }
        ToggleTorch(torchIsOn);

        animator.SetBool("Standing", isStanding);

        ladders = new List<GameObject>();
    }

    void Update()
    {
        Movement();
        UpdateTorch();

        if (controller.isGrounded && controller.velocity.magnitude > 2 && GetComponent<AudioSource>().isPlaying == false)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    void FixedUpdate()
    {
        
    }

    public void OnMove(InputAction.CallbackContext context) // AD Keys
    {
        inputVector = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context) // Spacebar Key
    {
        if (context.performed)
        {
            isJumping = true;
        }
    }

    public void OnPause(InputAction.CallbackContext context) // ESC Key
    {
        isPaused = context.performed;
        pauseMenu.Pause(isPaused);
    }

    public void OnPickUp(InputAction.CallbackContext context) // E Key
    {
        isPicked = context.performed;
    }

    public void OnDrop(InputAction.CallbackContext context) // R Key
    {
        tempObj.GetComponent<MoveObject>().DropDown();
    }

    void Movement()
    {
        if (!isStanding)
        {
            if (inputVector != Vector2.zero)
            {
                isStanding = true;
                animator.SetBool("Standing", isStanding);
            }

            return;
        }

        if (controller.isGrounded)
        {
            animator.SetBool("Grounded", true);
            currentVerticalSpeed = 0;
            moveVector.x = inputVector.x * movementSpeed;
            animator.SetFloat("Speed", moveVector.x); // animator thing

            if (moveVector.x > 0.1) // flip sprite
            {
                spriteRenderer.flipX = true;
                animator.SetBool("flipped", true);
            }
            if (moveVector.x < -0.1)
            {
                spriteRenderer.flipX = false;
                animator.SetBool("flipped", false);
            }

            if (isJumping) 
            { 
                currentVerticalSpeed = jumpSpeed;
                soundManager.PlaySound(clips[1]);
                animator.SetTrigger("Jump");
                animator.SetBool("Grounded", false);
            }
        }
        else 
        { 
            moveVector.x = inputVector.x * movementSpeed / 2; 
        }

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

    void UpdateTorch()
    {
        

        if (inventory.Contains(PlayerInventory.InvetoryItem.Torch))
        {
            if (Input.GetButtonDown("Torch"))
            {
                ToggleTorch(!torchIsOn);
            }            
        }
        else
        {
            if (isPicked && torchOnGround != null && Vector3.Distance(torchOnGround.transform.position, transform.position) < 1)
            {
                inventory.Add(PlayerInventory.InvetoryItem.Torch);
                ToggleTorch(true);
                Destroy(torchOnGround);
            }
        }
    }

    void ToggleTorch(bool isOn)
    {
        torchIsOn = isOn;
        torchController.gameObject.SetActive(torchIsOn);
        animator.SetBool("TorchOn", torchIsOn);
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
        if(hit.collider.gameObject.TryGetComponent<MoveObject>(out MoveObject moveObject))
        {
            if (isPicked)
            {
                hit.collider.gameObject.GetComponent<MoveObject>().PickUp();
                tempObj = hit.collider.gameObject;
            }
        }
    }
}
