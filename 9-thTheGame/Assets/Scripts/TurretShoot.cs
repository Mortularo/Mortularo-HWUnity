using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class TurretShoot : MonoBehaviour
{
    public GameObject canBall;
    public GameObject _target;
    public Transform barrel;
    public float cSpeed = 10f;
    public float sDistanse = 10f;
    public float _range = 10f;
    public float fireRate = 5f;
    private float _fireRate;
    //public AudioClip shot;

    void Update()
    {
        float range = Vector3.Distance(_target.transform.position, transform.position);
        /*if (_fireRate < fireRate)
        {
            _fireRate += Time.deltaTime;
        }*/
        if (range <= _range /*&& _fireRate<fireRate*/)
        {
            Shoot();
        }

    }
    void Shoot()
    {
        RaycastHit hit;
        Vector3 curTarget = _target.transform.position - barrel.position;
        if (Physics.Raycast(barrel.transform.position, barrel.transform.forward, out hit, _range))
        {
            //Debug.Log("Got it");
            GameObject nextBall = Instantiate(canBall, barrel.position, Quaternion.identity);
            nextBall.GetComponent<Rigidbody>().AddForce(curTarget.normalized * cSpeed, ForceMode.Impulse);
        }
        //_fireRate = 0;
    }
}