using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private enum Phase { FORWARD, BACK, FORWARD2, FALL, CUT }
    private Phase phase;

    [SerializeField] float distance;
    [SerializeField] float smooth;

    [SerializeField] Vector3 forwardVector;
    [SerializeField] Vector3 forwardVector2;
    [SerializeField] Vector3 backVector;
    [SerializeField] Vector3 fallVector;
    [SerializeField] Vector3 cutVector;

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
            if(phase == Phase.FORWARD || phase == Phase.FORWARD2)
                phase = Phase.FALL;
            else if(phase == Phase.BACK)
                phase = Phase.FORWARD2;
                
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
            case Phase.FORWARD2:
                targetVector = forwardVector2;
                break;
            case Phase.CUT:
                targetVector = cutVector;
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

    public void CutOrder()
    {
        canMove = true;
        phase = Phase.CUT;
        SetTarget();
    }

}
