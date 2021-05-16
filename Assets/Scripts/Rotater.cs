using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public enum Phase { BEGIN, START, FLIP, SLOW, END }

    private Phase phase = Phase.BEGIN;

    [SerializeField] GameObject knife;
    [SerializeField] float standartSpeed;
    [SerializeField] float slowSpeed;
    [SerializeField] float minSpeed;
    [SerializeField] float rotTime;

    private float speed = 0;
    private float angle = 270;

    private void FixedUpdate() 
    {
        Rotate();
    }

    public void StopOrder()
    {
        speed = 0;
        phase = Phase.BEGIN;
    }

    public void FlipOrder()
    {
        phase = Phase.FLIP;
    }

    private void Rotate()
    {
        SetSpeed();

        angle += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void SetSpeed()
    {
        float current = angle % 360;
        speed = 0;

        switch (phase)
        {
            case Phase.FLIP:
                speed = ConfigureMaxSpeed();
                if (current >= 355)
                    phase = Phase.SLOW;
                break;
            case Phase.SLOW:
                speed = slowSpeed;
                if (current >= 70)
                    phase = Phase.END;
                break;
            case Phase.END:
                speed = minSpeed;
                break;
        }
    }

    private float ConfigureMaxSpeed()
    {
        float current = angle % 360;
        if(current < 270)
        {
            float difference = 355f - current;
            return (difference / rotTime);
        }

        return standartSpeed;
    }
}
