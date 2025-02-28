using Unity.Cinemachine;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CinemachineCamera freeLookCamera;
    private Rigidbody playerRB;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 8f;
    private bool isGrounded;

    public InputManager inputManager;

    void Start()
    {

        playerRB = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer);
        inputManager.OnSpacePressed.AddListener(Jump);
     

    }

    private void Update()
    {
        transform.rotation = Quaternion.Euler(0, freeLookCamera.transform.eulerAngles.y, 0);
    }


    void MovePlayer(Vector2 input)
    { 

        //camera's forward and right directions
        Vector3 cameraForward = freeLookCamera.transform.forward;
        Vector3 cameraRight = freeLookCamera.transform.right;

        //only move on the XZ plane
        cameraForward.y = 0;
        cameraRight.y = 0;

       
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate movement direction 
        Vector3 inputXYZPlane = cameraForward * input.y + cameraRight * input.x;


        // Apply movement force to player
        playerRB.AddForce(inputXYZPlane * speed);
    }

    void Jump()
    {
        
        if (isGrounded)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); 
            isGrounded = false; 
        }
    }

    // Called when player collides with something
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.collider.CompareTag("Platform")) 
        {
            isGrounded = true; 
        }
    }

  
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Platform")) 
        {
            isGrounded = false; 
        }
    }




}
