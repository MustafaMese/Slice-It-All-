using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerController : MonoBehaviour
{
    [SerializeField] InputManager inputManager;

    private void Start() 
    {
        inputManager = GetComponent<InputManager>();    
    }

    public void Receive(TriggerType trigger)
    {
        switch (trigger)
        {
            case TriggerType.EDGE:
                inputManager.Stop();
                break;
            case TriggerType.GRASP:
                inputManager.Flip(false);
                break;
        }
        
    }
}

public enum TriggerType { EDGE, GRASP }
