using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLimit : SingletonBase<TimeLimit>
{
    public int secondsLeft;
    public int milisecondLimit;
    float miliseconds;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        miliseconds = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void TimeTick() 
    {
        miliseconds += Time.deltaTime;
    }

    void OneLessSecond() 
    {
        if (miliseconds >= milisecondLimit)
        {
            secondsLeft--;
            miliseconds = 0;
        }
    }

    public bool TimeIsUp() 
    {
        if (secondsLeft <= 0)
            return true;
        return false;
    }

    public float GetSecondsLeft() 
    {
        return secondsLeft;
    }

    protected override void BehaveSingleton()
    {
        TimeTick();
        OneLessSecond();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
