using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMoveManager : MonoBehaviour
{
    public void CheckAdequateMovement() 
    {
        if (this.gameObject.GetComponent<RockGoalDistanceDeterminer>().AlmostNearTheGoal()) 
        {
            this.gameObject.GetComponent<RockToGoal>().enabled = true;
            this.gameObject.GetComponent<RockToGoal>().BackEnabled();
            this.gameObject.GetComponent<RockMovement>().enabled = false;
        }
    }

    public void RestartRock() 
    {
        this.gameObject.GetComponent<RockMovement>().enabled = true;
        this.gameObject.GetComponent<RockMovement>().ZeroEverything();
        this.gameObject.GetComponent<RockToGoal>().enabled = false;
    }
}
