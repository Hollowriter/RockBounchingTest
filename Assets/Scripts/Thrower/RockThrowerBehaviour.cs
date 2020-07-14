using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrowerBehaviour : MonoBehaviour
{
    // Angle (Pending)
    // Strength (Pending)
    public int timeForThrow;
    float time;
    GameObject rock;

    private void Awake()
    {
        time = 0;
        rock = null;
    }

    void TimeTick() 
    {
        time += Time.deltaTime;
    }

    void ResetTime() 
    {
        if (time >= timeForThrow)
        {
            time = 0;
        }
    }

    void FetchRock() 
    {
        if (time >= timeForThrow) 
        {
            rock = RockPool.instance.FetchMeARock();
            rock.transform.position = transform.position;
            Debug.Log("FetchRock");
        }
    }

    void ThrowRock() 
    {
        if (rock != null) 
        {
            rock.GetComponent<RockMovement>().SetAngle(45); // Hardcode to test
            rock.GetComponent<RockMovement>().SetSpeed(2); // Hardcode to test
            rock = null;
        }
    }

    void Behave() 
    {
        TimeTick();
        FetchRock();
        ThrowRock();
        ResetTime();
    }

    private void Update()
    {
        Behave();
    }
}
