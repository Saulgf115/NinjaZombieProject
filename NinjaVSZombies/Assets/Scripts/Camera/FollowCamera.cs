using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    //Transform myTransform;
     Transform playerTarget;

    
    public Vector3 offset = new Vector3(3.0f,7.5f,9.92f);

    // Start is called before the first frame update
    void Start()
    {
        //myTransform = this.transform;
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget)
        {
            transform.position = playerTarget.position + offset;
            transform.LookAt(playerTarget,Vector3.up);
        }
    }
}
