using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockClock : MonoBehaviour
{
    float time;

    void BeforeBeggining() 
    {
        time = 0;
    }

    private void Awake()
    {
        BeforeBeggining();
    }

    void TimeTick() 
    {
        time += Time.deltaTime;
    }

    public void SetTime(float _time) 
    {
        time = _time;
    }

    public float GetTime() 
    {
        return time;
    }

    void Behave() 
    {
        TimeTick();
    }

    private void Update()
    {
        Behave();
    }
}
