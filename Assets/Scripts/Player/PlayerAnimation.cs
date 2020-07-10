using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : SingletonBase<PlayerAnimation>
{
    Animator playerAnimator;
    SpriteRenderer playerSprite;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerAnimator = GetComponent<Animator>();
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        SingletonAwake();
    }

    public void Idle() 
    {
        playerAnimator.SetBool("WalkPressed", false);
    }

    public void WalkLeft() 
    {
        playerAnimator.SetBool("WalkPressed", true);
        playerSprite.flipX = true;
    }

    public void WalkRight() 
    {
        playerAnimator.SetBool("WalkPressed", true);
        playerSprite.flipX = false;
    }
}
