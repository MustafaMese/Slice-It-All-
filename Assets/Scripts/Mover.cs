using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private enum Phase { FORWARD, BACK, FALL }
    private Phase phase;

    [SerializeField] float distance;
    [SerializeField] float smooth;

    [SerializeField] Vector3 forwardVector;
    [SerializeField] Vector3 backVector;
    [SerializeField] Vector3 fallVector;

    private Vector3 targetVector;
    private Vector3 targetPos;
    private bool canMove;

    private void FixedUpdate()
    {
        if (canMove)
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * smooth);
        if (Vector3.Distance(transform.position, targetPos) < distance)
        {
            if(phase == Phase.FORWARD)
                phase = Phase.FALL;
            else if(phase == Phase.BACK)
                phase = Phase.FORWARD;
                
            SetTarget();
        }
    }

    private void SetTarget()
    {
        switch (phase)
        {
            case Phase.FORWARD:
                targetVector = forwardVector;
                break;
            case Phase.FALL:
                targetVector = fallVector;
                break;
            case Phase.BACK:
                targetVector = backVector;
                break;
        }

        targetPos = transform.position + targetVector;
    }

    public void StopOrder()
    {
        canMove = false;
    }

    public void FlipOrder()
    {
        canMove = true;
        phase = Phase.FORWARD;
        SetTarget();
    }

    public void BackFlipOrder()
    {
        canMove = true;
        phase = Phase.BACK;
        SetTarget();
    }
}
