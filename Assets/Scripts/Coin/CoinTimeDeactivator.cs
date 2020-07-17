using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinTimeDeactivator : MonoBehaviour
{
    public float timeToDeactivate;
    float time;

    private void Awake()
    {
        time = 0;
    }

    void TimeTick() 
    {
        time += Time.deltaTime;
    }

    void DeactivateCoin() 
    {
        if (time >= timeToDeactivate) 
        {
            time = 0;
            this.gameObject.SetActive(false);
        }
    }

    void Behave() 
    {
        TimeTick();
        DeactivateCoin();
    }

    private void Update()
    {
        Behave();
    }
}
