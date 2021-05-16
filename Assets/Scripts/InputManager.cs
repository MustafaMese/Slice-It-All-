using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InputManager : MonoBehaviour
{
    [SerializeField] Mover mover;
    [SerializeField] Rotater rotater;

    private void Update() 
    {
        if(Input.GetMouseButtonDown(0))
        {
            Flip();
        }
    }

    public void Flip()
    {
        mover.FlipOrder();
        rotater.FlipOrder();
    }

    public void Stop()
    {
        mover.StopOrder();
        rotater.StopOrder();
    }
}
