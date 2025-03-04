using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, rotationSpeed, 0);
    }
}
