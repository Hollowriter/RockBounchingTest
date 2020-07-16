using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCounter : SingletonBase<RockCounter>
{
    int rocksInserted;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rocksInserted = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void SetRocksInserted(int _rocksInserted) 
    {
        rocksInserted = _rocksInserted;
    }

    public int GetRocksInserted() 
    {
        return rocksInserted;
    }
}
