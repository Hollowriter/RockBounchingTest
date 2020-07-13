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
    float time;
    float ascendFactor;

    void ZeroEverything() 
    {
        distanceHorizontal = 0;
        heightVertical = 0;
        MAXHEIGHT = 0;
        speed = 2; // Cambiar solo en testing
        time = 0;
        angle = Mathf.PI * 45 / 180.0f; // Cambiar solo en testing
        rockPosition = Vector3.zero;
        ascendFactor = 1;
    }

    void InitializeMaxHeight() 
    {
        MAXHEIGHT = Mathf.Pow(speed, 2) * Mathf.Pow(Mathf.Sin(angle), 2) / 2 * Gravity.instance.gravity;
    }

    private void Awake()
    {
        ZeroEverything();
    }

    private void Start()
    {
        rockPosition = GetComponent<Transform>().position;
        InitializeMaxHeight();
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

    public void Bounce() 
    {
        ascendFactor *= -1;
    }

    void MovementTimer() 
    {
        time += Time.deltaTime;
    }

    void ParableMovementVertical() 
    {
        heightVertical = rockPosition.y + speed * Mathf.Sin(angle) * time - 0.5f * (Gravity.instance.gravity * ascendFactor) * (time * time);
        if (ascendFactor == -1 && rockPosition.y >= MAXHEIGHT) 
        {
            ascendFactor *= -1;
            time = speed;
        }
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
