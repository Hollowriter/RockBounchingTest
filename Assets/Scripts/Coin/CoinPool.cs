using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPool : SingletonBase<CoinPool>
{
    [SerializeField]
    GameObject instantiableCoin;
    GameObject[] coins;
    [SerializeField]
    int poolSize;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        coins = new GameObject[poolSize];
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void FillCoinPool() 
    {
        for (int i = 0; i<poolSize; i++) 
        {
            GameObject singleCoin = (GameObject)Instantiate(instantiableCoin, transform);
            coins[i] = singleCoin;
            coins[i].SetActive(false);
        }
    }

    private void Start()
    {
        FillCoinPool();
    }

    public GameObject MakeCoinAppear() 
    {
        for (int i = 0; i<poolSize; i++) 
        {
            if (!coins[i].activeInHierarchy)
            {
                coins[i].SetActive(true);
                return coins[i];
            }
        }
        return coins[poolSize - 1];
    }
}
