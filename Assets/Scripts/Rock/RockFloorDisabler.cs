using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFloorDisabler : MonoBehaviour
{
    public float onFloorDisableTime;
    bool onFloor;
    RockClock clock;

    void BeforeBeginning() 
    {
        clock = this.gameObject.GetComponent<RockClock>();
        onFloor = false;
    }

    private void Awake()
    {
        BeforeBeginning();
    }

    public void ConfirmCollisionWithFloor() 
    {
        onFloor = true;
    }

    void Disable() 
    {
        if (onFloor == true && clock.GetTime() >= onFloorDisableTime) 
        {
            onFloor = false;
            this.gameObject.SetActive(false);
        }
    }

    void Behave() 
    {
        Disable();
    }

    private void Update()
    {
        Behave();
    }
}
