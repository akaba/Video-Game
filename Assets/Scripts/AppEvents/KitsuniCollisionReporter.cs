using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitsuniCollisionReporter : MonoBehaviour
{
    void OnCollisionEnter(Collision c)
    {

        foreach (ContactPoint contact in c.contacts)
        {
            if (c.impulse.magnitude > 0.25f)
            {

                EventManager.TriggerEvent<BoxCollisionEvent, Vector3, float>(contact.point, c.impulse.magnitude);
            }
        }

    }
}
