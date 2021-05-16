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
        inputManager.Stop();

        switch (trigger)
        {
            case TriggerType.EDGE:

                break;
            case TriggerType.GRASP:

                break;
        }
        
    }
}

public enum TriggerType { EDGE, GRASP }
