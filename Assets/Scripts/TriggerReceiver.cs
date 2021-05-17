using System;
using System.Collections;
using System.Collections.Generic;
using EzySlice;
using UnityEngine;

public class TriggerReceiver : MonoBehaviour
{
    [SerializeField] TriggerController trigger;
    [SerializeField] TriggerType triggerType;

    private void OnTriggerEnter(Collider other) 
    {
        switch (triggerType)
        {
            case TriggerType.EDGE:
                if (other.tag == "Platform")
                    trigger.Receive(triggerType);
                else if (other.tag == "Cuttable")
                    Cut(other);
                break;
            case TriggerType.GRASP:
                trigger.Receive(triggerType);
                break;
        }
        
    }

    private void Cut(Collider other)
    {
        GameObject shorn = other.gameObject;
        SlicedHull hull = shorn.Slice(transform.position, transform.forward);
    
        if(hull != null)
        {
            GameObject lower = hull.CreateLowerHull(shorn, shorn.GetComponent<Renderer>().material);
            GameObject upper = hull.CreateUpperHull(shorn, shorn.GetComponent<Renderer>().material);

            Rigidbody rb1 = lower.AddComponent<Rigidbody>();
            lower.AddComponent<MeshCollider>().convex = true;
            rb1.AddForce(-transform.forward * 200f, ForceMode.Force);

            Rigidbody rb2 = upper.AddComponent<Rigidbody>();
            upper.AddComponent<MeshCollider>().convex = true;
            rb2.AddForce(transform.forward * 200f, ForceMode.Force);

        }

        shorn.SetActive(false);
    }
}
