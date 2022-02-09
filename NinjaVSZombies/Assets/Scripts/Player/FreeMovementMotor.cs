using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMovementMotor : MonoBehaviour
{
    [HideInInspector]
    public Vector3 movementDirection;

    public Rigidbody rb;

    public float walkingSpeed = 7.0f;
    public float walkingSnapyness = 50.0f;
    public float turningSmoothing = 0.3f;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 targetVelocity = movementDirection * walkingSpeed;

        Vector3 deltaVelocity = targetVelocity - rb.velocity;

        if(rb.useGravity)
        {
            deltaVelocity.y = 0.0f;
        }

        rb.AddForce(deltaVelocity *  walkingSnapyness,ForceMode.Acceleration);

        Vector3 facingDirection = movementDirection;

        if(facingDirection == Vector3.zero)
        {
            rb.angularVelocity = Vector3.zero;
        }
        else
        {
            float rotationAngle = AngleAroundAxis(transform.forward,facingDirection,Vector3.up);

            rb.angularVelocity = Vector3.up * rotationAngle * turningSmoothing;
        }

    }


    float AngleAroundAxis(Vector3 directionA,Vector3 directionB,Vector3 axis)
    {
        directionA = directionA - Vector3.Project(directionA,axis);

        directionB = directionB - Vector3.Project(directionB, axis);

        float angle = Vector3.Angle(directionA,directionB);

        return angle * (Vector3.Dot(axis,Vector3.Cross(directionA,directionB)) < 0 ? -1 : 1);
    }
}
