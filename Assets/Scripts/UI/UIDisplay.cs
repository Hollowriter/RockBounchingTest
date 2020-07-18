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

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        rockText.text = "x" + 0;
        coinText.text = "x" + 0;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    void CheckInfoSources() 
    {
        rockText.text = "x" + RockCounter.instance.GetRocksInserted();
        coinText.text = "x" + CoinCounter.instance.GetCoinsCollected();
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
