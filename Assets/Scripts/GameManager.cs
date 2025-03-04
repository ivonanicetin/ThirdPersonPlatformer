using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private float score = 0;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void IncrementScore()
    {
        score++;
    }
}
