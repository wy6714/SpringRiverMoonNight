using UnityEngine;

public class Tornado : MonoBehaviour
{
    public Transform positionA;
    public Transform positionB;
    public Transform positionC;

    private Transform targetPosition;

    private void Start()
    {
        // Start by moving to PositionA
        SetTargetPosition(positionA);
    }

    private void Update()
    {
        // Move towards the target position
        float speed = 5f; // You can adjust the speed as needed

        transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);

        // Check if the object has reached the target position
        if (Vector3.Distance(transform.position, targetPosition.position) < 0.01f)
        {
            // Change the target position based on the current position
            if (targetPosition == positionA)
            {
                SetTargetPosition(positionB);
            }
            else if (targetPosition == positionB)
            {
                SetTargetPosition(positionC);
            }
            else
            {
                SetTargetPosition(positionA);
            }
            // You can add more conditions for additional positions if needed
        }
    }

    private void SetTargetPosition(Transform newTarget)
    {
        // Set the new target position
        targetPosition = newTarget;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(positionA.position, 0.5f);
        Gizmos.DrawWireSphere(positionB.position, 0.5f);
        Gizmos.DrawWireSphere(positionC.position, 0.5f);
    }
}
