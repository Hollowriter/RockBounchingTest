using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : SingletonBase<CoinCounter>
{
    int coinsCollected;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        coinsCollected = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetCoinsCollected(int _coinsCollected) 
    {
        coinsCollected = _coinsCollected;
    }

    public int GetCoinsCollected() 
    {
        return coinsCollected;
    }
}
