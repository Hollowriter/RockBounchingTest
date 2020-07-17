using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : SingletonBase<CameraFollower>
{
    Vector3 moveVector;
    float camVertExtent;
    float camHorzExtent;
    float leftConstraint;
    float rightConstraint;

    void CalculateCameraLimits() 
    {
        camVertExtent = this.gameObject.GetComponent<Camera>().orthographicSize;
        camHorzExtent = this.gameObject.GetComponent<Camera>().aspect * camVertExtent;
        leftConstraint = AreaConstraints.instance.LeftStageLimit + camHorzExtent;
        rightConstraint = AreaConstraints.instance.RightStageLimit - camHorzExtent;
    }

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        moveVector = Vector3.zero;
        CalculateCameraLimits();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    /*bool ShouldFollow() 
    {
        if (Input.GetKey(InputHandler.instance.walkLeft)) 
        {
            if ()
        }
        return false;
    }*/

    void Follow() 
    {
        if (Input.GetKey(InputHandler.instance.walkLeft) || Input.GetKey(InputHandler.instance.walkRight))
        {
            /*if (transform.position.x > AreaConstraints.instance.LeftStageLimit && transform.position.x < AreaConstraints.instance.RightStageLimit)
            {*/
                moveVector.x = Mathf.Clamp(PlayerMovement.instance.transform.position.x, leftConstraint, rightConstraint);
                moveVector.y = this.gameObject.transform.position.y;
                moveVector.z = this.gameObject.transform.position.z;
                transform.position = moveVector;
            // }
        }
    }

    protected override void BehaveSingleton()
    {
        Follow();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
