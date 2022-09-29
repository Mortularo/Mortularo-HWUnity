using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretTracking : MonoBehaviour
{
    public float rSpeed = 5f;
    public GameObject nTarget = null;
    Vector3 setPoint = Vector3.zero;
    Quaternion rescueRotation;

    void Update()
    {
        if (nTarget)
        {
            if (setPoint != nTarget.transform.position)
            {
                setPoint = nTarget.transform.position;
                rescueRotation = Quaternion.LookRotation(setPoint - transform.position);
            }
            if (transform.rotation != rescueRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rescueRotation, rSpeed * Time.deltaTime);
             }
        }
    }
    bool SetTarget(GameObject target)
    {
        if(target)
        {
            return false;
        }
        nTarget = target;
        return true;
    }
}
