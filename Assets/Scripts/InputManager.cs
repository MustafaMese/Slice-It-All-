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
            Flip(true);
        }
    }

    public void Flip(bool forward)
    {
        if(forward)
            mover.FlipOrder();
        else
            mover.BackFlipOrder();

        rotater.FlipOrder();
    }

    public void Stop()
    {
        mover.StopOrder();
        rotater.StopOrder();
    }

    public void Cut()
    {
        mover.CutOrder();
        rotater.CutOrder();
    }
}
