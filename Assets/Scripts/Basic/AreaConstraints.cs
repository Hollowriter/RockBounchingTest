using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaConstraints : SingletonBase<AreaConstraints>
{
    public float LeftStageLimit;
    public float RightStageLimit;
    protected override void SingletonAwake()
    {
        base.SingletonAwake();
    }

    private void Awake()
    {
        SingletonAwake();
    }
}
