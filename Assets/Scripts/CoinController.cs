using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 2f;
    public bool isCoinCollected  = false;

    // Update is called once per frame
    void Update()
    {

        transform.Rotate(0, rotationSpeed, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isCoinCollected = true;
            Destroy(gameObject);
        }
    }
}
