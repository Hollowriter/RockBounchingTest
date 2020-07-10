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
            PlayerAnimation.instance.WalkLeft();
        }
    }

    void PressedRight() 
    {
        if (Input.GetKey(InputHandler.instance.walkRight)) 
        {
            PlayerMovement.instance.MoveRight();
            PlayerAnimation.instance.WalkRight();
        }
    }

    void NonePressed() 
    {
        PlayerAnimation.instance.Idle();
    }

    void CheckKeys() 
    {
        if (InputHandler.instance.inputDetected()) 
        {
            PressedLeft();
            PressedRight();
        }
        else 
        {
            NonePressed();
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
