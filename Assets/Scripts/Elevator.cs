using UnityEngine;

public class Elevator : MonoBehaviour
{
    public float height2 = 5f;
    public float speed = 3f;

    // Private Variables
    Vector3 startPosition;
    bool reachTarget;

    void Start()
    {
        startPosition = transform.position;
    }


    void Update()
    {
        float targetHeight;

        if (reachTarget)
            targetHeight = height2;
        else
            targetHeight = startPosition.y;
        
        Vector3 targetPosition = new Vector3(startPosition.x, targetHeight, startPosition.z);

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void ToggleReachTarget()
    {
        reachTarget = !reachTarget;
    }
}
