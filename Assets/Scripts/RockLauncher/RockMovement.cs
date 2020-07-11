using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMovement : MonoBehaviour
{
    Vector3 rockPosition;
    float distanceHorizontal;
    float heightVertical;
    float speed;
    float angle;
    float time;

    void ZeroEverything() 
    {
        distanceHorizontal = 0;
        heightVertical = 0;
        speed = 0;
        time = 0;
        angle = 0;
        rockPosition = Vector3.zero;
    }

    private void Awake()
    {
        ZeroEverything();
    }

    private void Start()
    {
        rockPosition = GetComponent<Transform>().position;
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

    public double GetAngle() 
    {
        return angle;
    }

    void MovementTimer() 
    {
        time += Time.deltaTime;
    }

    void ParableMovementVertical() 
    {
        heightVertical = rockPosition.y + speed * Mathf.Sin(angle) * time - 0.5f * Gravity.instance.gravity * (time * time);
    }

    void ParableMovementHorizontal() 
    {
        distanceHorizontal = speed * Mathf.Cos(angle) * time;
    }

    void PassDirectionToTransform() 
    {
        rockPosition.x += distanceHorizontal * Time.deltaTime;
        rockPosition.y += heightVertical * Time.deltaTime;
        GetComponent<Transform>().position = rockPosition;
    }

    void ApplyParableMovement() 
    {
        MovementTimer();
        ParableMovementHorizontal();
        ParableMovementVertical();
        PassDirectionToTransform();
    }

    private void Update()
    {
        ApplyParableMovement();
    }
}
