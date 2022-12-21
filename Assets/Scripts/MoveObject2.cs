using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject2 : MonoBehaviour
{
    public MoveObject2 follower;

    [SerializeField]
    float steeringSpeed;

    [SerializeField]
    float maxSpeed;

    [SerializeField]
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetDirection();
    }

    void GetDirection()
    {
        Vector3 direction =
            follower.transform.position - this.transform.position;
        Vector3 normalizeDirection = direction.normalized;
        rb.velocity += direction * steeringSpeed;
        float speed = 0f;
        float distance = 2f;

        if (distance > 0.5f)
        {
            speed = maxSpeed;
        }
        rb.velocity = Truncate(rb.velocity, speed);
    }

    Vector3 Truncate(Vector3 direction, float maxSpeed)
    {
        direction = Vector3.ClampMagnitude(direction, maxSpeed);
        return direction;
    }
}
