using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawnConditions : SingletonBase<CoinSpawnConditions>
{
    public int rocksInsertedToSpawn;
    int limitMultiplier;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        limitMultiplier = 1;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckToSpawn() 
    {
        if (RockCounter.instance.GetRocksInserted() >= rocksInsertedToSpawn * limitMultiplier) 
        {
            limitMultiplier++;
            CoinPositioner.instance.PositionCoin();
        }
    }

    protected override void BehaveSingleton()
    {
        CheckToSpawn();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
