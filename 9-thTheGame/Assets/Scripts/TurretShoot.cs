using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class TurretShoot : MonoBehaviour
{
    public GameObject canBall;
    public GameObject _target;
    public Transform barrel;
    public float cSpeed = 10f;
    public float sDistanse = 10f;
    public float _range = 10f;
    public int maxShots = 1;
    private int curentShots;
    //public AudioClip shot;

    void Update()
    {
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, _range))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Shoot();
            }
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        Vector3 curTarget = _target.transform.position - barrel.position;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, _range))
        {
            GameObject nextBall = Instantiate(canBall, barrel.position, Quaternion.identity);
            nextBall.GetComponent<Rigidbody>().AddForce(curTarget.normalized * cSpeed, ForceMode.Impulse);
            
        }
        
    }
}
