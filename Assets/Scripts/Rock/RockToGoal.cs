using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockToGoal : MonoBehaviour
{
    Vector3 rockPosition;
    float distanceHorizontal;
    float heightVertical;
    float speedInformed;
    float angleInformed;
    float timeInformed;
    float ascendFactor;

    void BeforeBeginning() 
    {
        rockPosition = GetComponent<Transform>().position;
        distanceHorizontal = 0;
        heightVertical = 0;
        speedInformed = 0;
        angleInformed = 0;
        timeInformed = 0;
        ascendFactor = 1;
        this.enabled = false;
    }

    private void Awake()
    {
        BeforeBeginning();
    }

    public void BackEnabled() 
    {
        rockPosition = GetComponent<Transform>().position;
        speedInformed = this.gameObject.GetComponent<RockMovement>().GetSpeed();
        angleInformed = this.gameObject.GetComponent<RockMovement>().GetAngle();
        timeInformed = this.gameObject.GetComponent<RockMovement>().GetSpeed();
    }

    void ModifyAscendFactor() 
    {
        if (rockPosition.x != Goal.instance.GetTransform().position.x) 
        {
            ascendFactor = -1;
            return;
        }
        ascendFactor = 1;
    }

    void TimeTick() 
    {
        timeInformed += Time.deltaTime;
    }

    void MovementVertical() 
    {
        heightVertical = rockPosition.y + (speedInformed * Mathf.Sin(angleInformed)) - 0.5f * (Gravity.instance.gravity * ascendFactor) * (timeInformed * timeInformed);
    }

    void MovementHorizontal() 
    {
        if (rockPosition.x != Goal.instance.GetTransform().position.x)
        {
            if (rockPosition.x > Goal.instance.GetTransform().position.x)
            {
                distanceHorizontal = 0;
                rockPosition.x = Goal.instance.GetTransform().position.x;
                return;
            }
            distanceHorizontal = speedInformed * Mathf.Cos(angleInformed) * timeInformed;
        }
    }

    void PassDirectionToTransform()
    {
        rockPosition.x += distanceHorizontal * Time.deltaTime;
        rockPosition.y += heightVertical * Time.deltaTime;
        GetComponent<Transform>().position = rockPosition;
    }

    void Behave() 
    {
        TimeTick();
        ModifyAscendFactor();
        MovementVertical();
        MovementHorizontal();
        PassDirectionToTransform();
    }

    private void Update()
    {
        Behave();
    }
}
