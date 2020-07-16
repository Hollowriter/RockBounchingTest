using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrowerBehaviour : MonoBehaviour
{
    float angle;
    float strength;
    public float minAngle;
    public float maxAngle;
    public float minStrength;
    public float maxStrength;
    public int timeForThrow;
    float time;
    GameObject rock;

    void Begin() 
    {
        time = 0;
        angle = 0;
        strength = 0;
        rock = null;
    }

    private void Awake()
    {
        Begin();
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
            rock.GetComponent<RockMovement>().SetRockPositionToTransform();
        }
    }

    void CalculateThrow() 
    {
        if (rock != null)
        {
            angle = Random.Range(minAngle, maxAngle);
            strength = Random.Range(minStrength, maxStrength);
        }
    }

    void ThrowRock() 
    {
        if (rock != null) 
        {
            rock.GetComponent<RockMovement>().SetAngle(angle);
            rock.GetComponent<RockMovement>().SetSpeed(strength);
            this.gameObject.GetComponent<RockThrowerAnimation>().ThrowAnimation();
            rock = null;
        }
    }

    void Behave() 
    {
        TimeTick();
        FetchRock();
        CalculateThrow();
        ThrowRock();
        ResetTime();
    }

    private void Update()
    {
        Behave();
    }
}
