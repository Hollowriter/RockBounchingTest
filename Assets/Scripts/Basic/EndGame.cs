using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : SingletonBase<EndGame>
{
    private void Awake()
    {
        SingletonAwake();
    }

    void FinishLevel() 
    {
        if (TimeLimit.instance.TimeIsUp())
            SceneManager.LoadScene("Menu");
    }

    protected override void BehaveSingleton()
    {
        FinishLevel();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
