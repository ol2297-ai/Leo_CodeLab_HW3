using UnityEngine;

public class move : MonoBehaviour
{
    public float score = 0.5f;
    public int lives = 3;
    public string name = "Bob";
    public bool gameOver = false;

    public float speed;

    public Vector3 originalPosition;
    public Vector3 targetPosition;

    public Vector3[] targetPositions;
    public int targetPositionIndex = 0;
    Vector2 twoDeePosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log(name);
        originalPosition = transform.position;
        // Debug.Log("HelloWorld");
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, targetPositions[targetPositionIndex]);
        if (distanceToTarget < 1)
        {
            targetPositionIndex++;
            targetPositionIndex = targetPositionIndex % targetPositions.Length;
        }
        // Debug.Log("Run Foever");
        transform.position = Vector3.MoveTowards(transform.position, targetPositions[targetPositionIndex], speed * Time.deltaTime);

        if (score < 10)
        {
            Debug.Log("You are Losing");
        }
    
}
}
