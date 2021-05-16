using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{
    [SerializeField] TriggerController trigger;
    [SerializeField] TriggerType triggerType;

    private void OnTriggerEnter(Collider other) 
    {
        trigger.Receive(triggerType);
    }
}
