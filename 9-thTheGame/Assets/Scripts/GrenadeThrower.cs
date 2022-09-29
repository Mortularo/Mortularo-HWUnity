using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeThrower : MonoBehaviour
{
    public float _thForce = 10f;
    public GameObject grenadePrefab;

    
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            ThrowGrenade();
        }
    }
    private void ThrowGrenade()
    {
        GameObject grenade = Instantiate(grenadePrefab, transform.position, transform.rotation);
        Rigidbody rb = grenade.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * _thForce, ForceMode.VelocityChange);
    }

}
