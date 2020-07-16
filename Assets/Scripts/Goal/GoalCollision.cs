using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCollision : SingletonBase<GoalCollision>
{
    private void Awake()
    {
        SingletonAwake();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Rock") 
        {
            collision.gameObject.SetActive(false);
        }
    }
}
