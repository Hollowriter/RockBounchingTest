using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGoalDistanceDeterminer : MonoBehaviour
{
    public float horizontalLimitDistance;
    float distanceGoalRock;

    private void Awake()
    {
        distanceGoalRock = 0;
    }

    void CalculateDistanceToGoal() 
    {
        distanceGoalRock = this.gameObject.GetComponent<Transform>().position.x - Goal.instance.GetTransform().position.x;
        if (distanceGoalRock < 0) 
        {
            distanceGoalRock *= -1;
        }
    }

    void Behave() 
    {
        CalculateDistanceToGoal();
    }

    private void Update()
    {
        Behave();
    }

    public bool AlmostNearTheGoal() 
    {
        if (distanceGoalRock <= horizontalLimitDistance)
            return true;
        return false;
    }
}
