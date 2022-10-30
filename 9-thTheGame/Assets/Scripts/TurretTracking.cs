using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretTracking : MonoBehaviour
{
    public float rSpeed = 5f;
    public GameObject _target = null;
    Vector3 setPoint = Vector3.zero;
    Quaternion rescueRotation;


    void Update()
    {
        
        if (_target)
        {
            if (setPoint != _target.transform.position)
            {
                setPoint = _target.transform.position;
                rescueRotation = Quaternion.LookRotation(setPoint - transform.position);
            }
            if (transform.rotation != rescueRotation)
            {
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rescueRotation, rSpeed * Time.deltaTime);
             }
        }
        else 
        {
            setPoint = Vector3.zero;
        }
    }
    bool SetTarget(GameObject target)
    {
        if(target)
        {
            return false;
        }
        _target = target;
        return true;
    }
}

