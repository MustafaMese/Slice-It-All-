using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    [SerializeField] float distance;
    [SerializeField] float smooth;
    [SerializeField] Vector3 targetVector = new Vector3(1, 0, 0);

    private Vector3 targetPos;
    private bool canMove;

    private void FixedUpdate()
    {
        if(canMove)
            Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * smooth);
        if (Vector3.Distance(transform.position, targetPos) < distance)
        {
            canMove = false;
            rb.useGravity = true;
            rb.isKinematic = false;
            targetPos = Vector3.zero;
        }
    }

    public void MoveOrder()
    {
        targetPos = transform.position + targetVector;
        canMove = true;
        rb.isKinematic = true;
        rb.useGravity = false;
    }
}
