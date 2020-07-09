using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : SingletonBase<PlayerController>
{
    private void Awake()
    {
        SingletonAwake();
    }

    void PressedLeft() 
    {
        if (Input.GetKey(InputHandler.instance.walkLeft)) 
        {
            PlayerMovement.instance.MoveLeft();
        }
    }

    void PressedRight() 
    {
        if (Input.GetKey(InputHandler.instance.walkRight)) 
        {
            PlayerMovement.instance.MoveRight();
        }
    }

    void CheckKeys() 
    {
        if (InputHandler.instance.inputDetected()) 
        {
            PressedLeft();
            PressedRight();
        }
    }

    protected override void BehaveSingleton()
    {
        CheckKeys();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
