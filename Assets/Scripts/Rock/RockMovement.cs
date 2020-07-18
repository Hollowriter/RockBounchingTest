using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    Vector3 rockPosition;
    float distanceHorizontal;
    float heightVertical;
    float MAXHEIGHT;
    float speed;
    float angle;
    RockClock clock;
    float ascendFactor;
    float verticalSpeedFactor;

    public void ZeroEverything() 
    {
        distanceHorizontal = 0;
        heightVertical = 0;
        MAXHEIGHT = 0;
        speed = 0;
        clock = this.gameObject.GetComponent<RockClock>();
        clock.SetTime(0);
        angle = 0;
        rockPosition = Vector3.zero;
        ascendFactor = 1;
        verticalSpeedFactor = 1;
    }

    void UpdateMaxHeight() 
    {
        MAXHEIGHT = (Mathf.Pow(speed, 2) * Mathf.Pow(Mathf.Sin(angle), 2) / (2 * Gravity.instance.gravity)) * verticalSpeedFactor;
    }

    private void Awake()
    {
        ZeroEverything();
    }

    public void SetRockPositionToTransform() 
    {
        rockPosition = GetComponent<Transform>().position;
    }

    private void Start()
    {
        SetRockPositionToTransform();
        UpdateMaxHeight();
    }

    public void SetSpeed(float _speed) 
    {
        speed = _speed;
    }

    public float GetSpeed() 
    {
        return speed;
    }

    public void SetAngle(float degrees) 
    {
        angle = Mathf.PI * degrees / 180.0f;
    }

    public float GetAngle() 
    {
        return angle;
    }

    public void Bounce(float bounceFactor) 
    {
        ascendFactor *= -1;
        verticalSpeedFactor *= bounceFactor;
    }

    void ParableMovementVertical() 
    {
        heightVertical = rockPosition.y + (speed * Mathf.Sin(angle) * verticalSpeedFactor) - 0.5f * Gravity.instance.gravity;
        if (rockPosition.y >= MAXHEIGHT) 
        {
            ascendFactor *= -1;
        }
    }

    void ParableMovementHorizontal() 
    {
        distanceHorizontal = speed * Mathf.Cos(angle);
    }

    void PassDirectionToTransform() 
    {
        rockPosition.x += distanceHorizontal * Time.deltaTime;
        rockPosition.y += heightVertical * ascendFactor * Time.deltaTime;
        GetComponent<Transform>().position = rockPosition;
    }

    void ApplyParableMovement() 
    {
        UpdateMaxHeight();
        ParableMovementHorizontal();
        ParableMovementVertical();
        PassDirectionToTransform();
    }

    private void Update()
    {
        ApplyParableMovement();
    }
}
