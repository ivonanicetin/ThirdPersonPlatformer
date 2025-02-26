using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float speed = 5f;
    public InputManager inputManager;

    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        inputManager.OnMove.AddListener(MovePlayer);
       
    }

    void MovePlayer(Vector2 input)
    {
        Vector3 inputXZPlane = new Vector3(input.x, 0, input.y);
        playerRB.AddForce(inputXZPlane * speed);
    }

    

   
}
