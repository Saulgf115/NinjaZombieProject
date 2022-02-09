using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveKeyboard : MonoBehaviour
{

    Animator animator;

    public FreeMovementMotor motor;
    public Transform playerTransform;


    Quaternion screenMovementSpace;
    Vector3 screenMovementForward;
    Vector3 screenMovementRight;

    // Start is called before the first frame update
    void Awake()
    {
        animator = GetComponent<Animator>();

        motor.movementDirection = Vector2.zero;
    }

    private void Start()
    {
        screenMovementSpace = Quaternion.Euler(0.0f,Camera.main.transform.eulerAngles.y,0.0f);
        screenMovementForward = screenMovementSpace * Vector3.forward;
        screenMovementRight = screenMovementSpace * Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        motor.movementDirection = Input.GetAxis(TagManager.HORIZONTAL_AXIS_NAME) * screenMovementRight + Input.GetAxis(TagManager.VERTICAL_AXIS_NAME) * screenMovementForward;

        if(Input.GetAxis(TagManager.HORIZONTAL_AXIS_NAME) != 0.0f || Input.GetAxis(TagManager.VERTICAL_AXIS_NAME) != 0.0f)
        {
            animator.SetBool(AnimationStates.ANIMATION_RUN, true);
        }
        else
        {
            animator.SetBool(AnimationStates.ANIMATION_RUN, false);
        }

        if(motor.movementDirection.sqrMagnitude > 1)
        {
            motor.movementDirection.Normalize();
        }

    }
}
