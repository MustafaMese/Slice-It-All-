using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public enum Phase { BEGIN, FLIP, END }

    private Phase phase = Phase.BEGIN;

    [SerializeField] GameObject knife;
    [SerializeField] float maxSpeed;
    [SerializeField] float minSpeed;

    private float speed = 0;
    private float angle = 270;

    private void FixedUpdate() 
    {
        Rotate();
    }

    private void Rotate()
    {
        speed = 0;
        switch (phase)
        {
            case Phase.FLIP:
                speed = maxSpeed;
                if (angle % 360 >= 355)
                    phase = Phase.END;
                break;
            case Phase.END:
                speed = minSpeed;
                break;
        }

        angle += Time.deltaTime * speed;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void RotateOrder()
    {
        phase = Phase.FLIP;
    }
}
