using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIDisplay : SingletonBase<UIDisplay>
{
    [SerializeField]
    Text rockText;
    [SerializeField]
    Text coinText;
    [SerializeField]
    Text timeText;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rockText.text = "x" + 0;
        coinText.text = "x" + 0;
        timeText.text = "0";
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckInfoSources() 
    {
        rockText.text = "x" + RockCounter.instance.GetRocksInserted();
        coinText.text = "x" + CoinCounter.instance.GetCoinsCollected();
        timeText.text = TimeLimit.instance.GetSecondsLeft().ToString(); ;
    }

    protected override void BehaveSingleton()
    {
        CheckInfoSources();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
