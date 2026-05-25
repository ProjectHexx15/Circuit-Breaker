using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance; // creates a static instance of this script

    [SerializeField] Transform playerCamera; // references the player cameras tranform component
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f; // stores a float value for smoothing out the mouses movement
    [SerializeField] bool cursorLock = true; // Locks the cursor in place in the middle of the screen
    public float mouseSensitivity = 3.5f; // Stores how sensitive the players mouse movement will be

    public float playerSpeed = 6.0f; // Stores how fast the player will move at
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.03f; // Stores a float value that will be used to make the players movements more smooth
    public float gravity = -30f; // stores a float value of the force of gravity that will affect the player and pull them down
    
    [SerializeField] Transform groundCheck; // references the transform component of the groundcheck GO
    [SerializeField] LayerMask ground; // references the ground layer, this will be used to check if the player is touching the ground or not and is ablet to jump

    public float jumpHeight = 6f; // stores a value of how high the player will be able to jump
    float velocityY; // this will store the players velocity on the Y-Axis
    bool IsGrounded; // this will be used to determine if the player is touching the ground and whether or not they are able to jump

    // mouse variables
    float cameraCap; // to store the constraint on the camera
    Vector2 currentMouseDelta;
    Vector2 currentMouseDeltaVelocity; // stores th current velocity of the mouse movement

    CharacterController charController; // references the players character controller component
    Vector2 currentDir; // stores the current direction the player is going in
    Vector2 currentDirVelocity; // stores the movement velocity in that direction
    Vector3 Velocity;

    private void Awake()
    {
        Instance = this; // ensure we are using this instance of the script (the one on the player)
    }

    // the start function is invoked when play is pressed
    void Start()
    {
       charController = GetComponent<CharacterController>(); // defines the CharacterController Component

        if(cursorLock) // checks if the cursor is locked
        {
            Cursor.lockState = CursorLockMode.Locked; // locks the cursor to the middle of the screen
            Cursor.visible = true; // the cursor is visible on the screen
        }

    } // end of start

    // the update function is called once per fram
    void Update()
    {
        UpdateMouse();
        UpdateMove();
        // The game will constantly call these two functions to see if there are any changes in the mouse or player movement
        
    } // end of update

    void UpdateMouse()
    {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); // creates a new vector 2 that will store the mouse movement

        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime); // this will dampen the movement between the target and the current position of the mouse

        cameraCap -= currentMouseDelta.y * mouseSensitivity; // defines the cameracap variable 
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f); // used mathf.clamp to set the limits in the y-axis

        playerCamera.localEulerAngles = Vector3.right * cameraCap; // we are specifically using angles
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity); // times camera movement by the mouse snesitivy and vectors to add force to the camera

    } // end of UpdateMouse

    void UpdateMove()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground); //defines the true condition for grounded and also defines its dimentions

        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); // uses a vector for a target direction when using the wasd keys to add instant force
        targetDir.Normalize(); // prevents the speed from doubling when holding down the movement keys

        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime); // Smoothes the force by dampening tbetween the instant push of the target and velocity and taking in the value of smoothmove

        velocityY += gravity * 2f * Time.deltaTime; // defines velocityY which is added and equal to gravity multiplied by 2f and time.deltatime

        Vector3 Velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * playerSpeed + Vector3.up * velocityY;
        // Defines another Vector3 velocity pushing forward * currenty and doing the same with the X-Axis * speed float. Vector up for upwards move *VelocityY

       charController.Move(Velocity * Time.deltaTime); // Moves the controller with the velocity variable which defines movement
       
        if (IsGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity); // if the jump button is pressed does a calculation with these value to launch the player into the air
        }
        if (IsGrounded! && charController.velocity.y < -1f)
        {
            velocityY = -8f;
        }


    } // end of UpdateMove



} // end of class
