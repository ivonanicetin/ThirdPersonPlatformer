using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5f;
    public float jumpForce = 8f;
    private bool isGrounded;

    public InputManager inputManager;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump);

    }

    void MovePlayer(Vector2 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        playerRB.AddForce(inputXZPlane * speed);
    }

    void Jump()
    {
        // Only allow jumping if the player is grounded
        if (isGrounded)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Add an upward force
            isGrounded = false; // Set grounded to false until OnCollisionEnter detects contact again
        }
    }

    // Called when player collides with something
    void OnCollisionEnter(Collision collision)
    {
        // Check if the player is touching a ground object
        if (collision.collider.CompareTag("Platform")) // You can tag the ground/platform as "Platform"
        {
            isGrounded = true; // Set grounded to true
        }
    }

    // Called when player stops colliding with something
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform")) // Ensure it's the platform we're leaving
        {
            isGrounded = false; // Set grounded to false once we exit the collision
        }
    }




}
