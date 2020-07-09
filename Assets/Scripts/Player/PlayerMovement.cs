using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class PlayerMovement : SingletonBase<PlayerMovement>
{
    Vector3 playerPosition;
    public float playerVelocity;

    protected override void SingletonAwake()
    {
        base.SingletonAwake();
        playerPosition = this.gameObject.GetComponent<Transform>().position;
    }

    private void Awake()
    {
        SingletonAwake();
    }

    /*void GravityActing()
    {
        playerPosition.y -= Gravity.instance.gravity * Time.deltaTime;
    }*/

    public void MoveLeft() 
    {
        if (playerPosition.x > AreaConstraints.instance.LeftStageLimit)
            playerPosition.x -= playerVelocity * Time.deltaTime;
    }

    public void MoveRight() 
    {
        if (playerPosition.x < AreaConstraints.instance.RightStageLimit)
            playerPosition.x += playerVelocity * Time.deltaTime;
    }

    void ApplyTranslation() 
    {
        this.gameObject.GetComponent<Transform>().position = playerPosition;
    }

    protected override void BehaveSingleton()
    {
        // GravityActing();
        ApplyTranslation();
    }

    private void Update()
    {
        BehaveSingleton();
    }
}
