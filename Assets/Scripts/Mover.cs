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
            ConfigureRigidbody(false);
            targetPos = Vector3.zero;
        }
    }

    public void StopOrder()
    {
        canMove = false;
        ConfigureRigidbody(true);
    }

    public void FlipOrder()
    {
        targetPos = transform.position + targetVector;
        canMove = true;
        ConfigureRigidbody(true);
    }

    private void ConfigureRigidbody(bool close)
    {
        if(close)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
        }
        
    }
}
