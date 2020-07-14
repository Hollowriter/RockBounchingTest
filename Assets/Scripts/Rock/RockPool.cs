using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPool : SingletonBase<RockPool>
{
    [SerializeField]
    GameObject instantiableRock;
    GameObject[] rocks;
    [SerializeField]
    int poolSize;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rocks = new GameObject[poolSize];
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void FillRockPool() 
    {
        for (int i = 0; i<poolSize; i++) 
        {
            GameObject singleRock = (GameObject)Instantiate(instantiableRock, transform);
            rocks[i] = singleRock;
            rocks[i].SetActive(false);
        }
    }

    private void Start()
    {
        FillRockPool();
    }

    public GameObject FetchMeARock() 
    {
        for (int i = 0; i<poolSize; i++) 
        {
            if (!rocks[i].activeInHierarchy) 
            {
                rocks[i].SetActive(true);
                return rocks[i];
            }
        }
        return rocks[poolSize - 1];
    }
}
