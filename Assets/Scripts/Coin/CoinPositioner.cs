using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPositioner : SingletonBase<CoinPositioner>
{
    float positionX;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        positionX = 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void PositionCoin() 
    {
        GameObject coin = CoinPool.instance.MakeCoinAppear();
        do 
        {
            positionX = Random.Range(0, AreaConstraints.instance.RightStageLimit);
        } while (positionX == PlayerMovement.instance.gameObject.transform.position.x);
        coin.transform.position = new Vector3(positionX, PlayerMovement.instance.gameObject.transform.position.y, 0);
    }
}
