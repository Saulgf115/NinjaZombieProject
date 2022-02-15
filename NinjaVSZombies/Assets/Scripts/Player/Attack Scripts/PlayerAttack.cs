using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    Animator animator;

    //animation states


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            animator.SetBool(AnimationStates.ANIMATION_ATTACK,true);
        }

        if (Input.GetKeyUp(KeyCode.I))
        {
            animator.SetBool(AnimationStates.ANIMATION_ATTACK, false);
        }

        
    }
}
