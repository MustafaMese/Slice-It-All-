using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    private enum Phase { RISE, FALL }
    private Phase phase;

    [SerializeField] Rigidbody rb;
    [SerializeField] float distance;
    [SerializeField] float smooth;

    [SerializeField] Vector3 riseVector;
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
            phase = Phase.FALL;
            SetTarget();
        }
    }

    private void SetTarget()
    {
        switch (phase)
        {
            case Phase.RISE:
                targetVector = riseVector;
                break;
            case Phase.FALL:
                targetVector = fallVector;
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
        phase = Phase.RISE;
        SetTarget();
    }
}
