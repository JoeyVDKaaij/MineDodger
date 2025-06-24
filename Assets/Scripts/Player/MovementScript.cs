using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class MovementScript : MonoBehaviour
{
    #region Variables
    
    [Header("Movement Settings")]
    [SerializeField, Tooltip("Set the movement speed")]
    private float movementSpeed = 7;
    [SerializeField, Tooltip("Set the drag when the player is standing on the ground.")]
    private float groundDrag = 5;

    [Header("Jumping Settings")]
    [SerializeField, Tooltip("Set the movement speed")]
    private float jumpForce = 12;
    [SerializeField, Tooltip("Set the cooldown when the player can jump again")]
    private float jumpCooldown = 0.25f;
    [SerializeField, Tooltip("Set the movement speed multiplier when the player is in the air.")]
    private float airMultiplier = 0.4f;
    [SerializeField, Tooltip("Set the movement speed multiplier when the player is in the air.")]
    private KeyCode jumpKey = KeyCode.Space;
    
    [Header("Technical Settings")]
    [SerializeField, Tooltip("Set the transform of the camera that the movement script is comparing to.")]
    private Transform cameraOrientation;
    [SerializeField, Tooltip("Set the height of the player.")]
    private float playerHeight;
    [SerializeField, Tooltip("Set the layermask of the ground.")]
    private LayerMask whatIsGround;
    [SerializeField, Tooltip("Set the collision check script.")]
    private CollisionCheckScript collisionCheck;
    
    private bool _grounded;
    private float _horizontalInput;
    private float _verticalInput;
    private Rigidbody _rb;
    private Vector3 _moveDirection;
    private bool _readyToJump = true;
    
    #endregion
    
    #region Unity Methods
    
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.freezeRotation = true;
        
        if (cameraOrientation == null)
            cameraOrientation = transform.GetChild(0);

        if (GameManager.instance != null)
        {
            GameManager.instance.gameplayType = GameplayTypes.Moving;
        }
    }
    
    void Update()
    {
        if ((GameManager.instance != null && GameManager.instance.gameplayType == GameplayTypes.Moving) || GameManager.instance == null)
        {
            if (collisionCheck != null)
            {
                _grounded = collisionCheck.CheckCollisionWithRayCast();
            }
            else _grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

            UserInput();

            SpeedControl();

            if (_grounded)
                _rb.linearDamping = groundDrag;
            else
                _rb.linearDamping = 0;
        }
    }
    
    private void FixedUpdate()
    {
        if ((GameManager.instance != null && GameManager.instance.gameplayType == GameplayTypes.Moving) || GameManager.instance == null)
        {
            MovePlayer();
        }
    }
    
    #endregion

    #region Movement Methods
    
    /// <summary>
    /// Get the user input using the Input.GetAxis() function
    /// Makes the player jump if the jump button is pressed
    /// </summary>
    private void UserInput()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(jumpKey) && _readyToJump && _grounded)
        {
            _readyToJump = false;
            
            Jump();
            
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    /// <summary>
    /// Move the player
    /// </summary>
    private void MovePlayer()
    {
        _moveDirection = transform.forward * _verticalInput + transform.right * _horizontalInput;
        
        if (_grounded)
            _rb.AddForce(_moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
        else
            _rb.AddForce(_moveDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    /// <summary>
    /// Ensures the player moves at the set movement speed (Ignores if the player is moving slower than the set movement speed).
    /// </summary>
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(_rb.linearVelocity.x, 0f, _rb.linearVelocity.z);

        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            _rb.linearVelocity = new Vector3(limitedVel.x, _rb.linearVelocity.y, limitedVel.z);
        }
    }

    /// <summary>
    /// Makes the object jump
    /// </summary>
    private void Jump()
    {
        // velocity changed to linearVelocity due to the changes between older versions of Unity and Unity 6
        _rb.linearVelocity = new Vector3(_rb.linearVelocity.x, 0, _rb.linearVelocity.z);
        
        _rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    /// <summary>
    /// Informs the script that the player can jump again
    /// </summary>
    private void ResetJump()
    {
        _readyToJump = true;
    }
    
    #endregion
    
}
