using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : SingletonBase<Goal>
{
    Transform goalTransform;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        goalTransform = GetComponent<Transform>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public Transform GetTransform() 
    {
        return goalTransform;
    }
}
