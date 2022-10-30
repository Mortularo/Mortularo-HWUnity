using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WeaponBomb : MonoBehaviour
{
    public float _delay = 3f;
    public float _radius = 5f;
    public float _force  = 500f;
    public int _damage = 10;

    public GameObject exposionEffect;

    float countdown;
    bool hasExploded = false;

    void Start()
    {
        countdown = _delay;
    }

    
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0 && !hasExploded)
        {
            Explode();
            hasExploded = true;
        }
    }

    void Explode()
    {
        Instantiate(exposionEffect, transform.position, transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);
        foreach (Collider nbObject in colliders)
        {
            Rigidbody rb = nbObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(_force, transform.position, _radius);
            }

            if (nbObject.gameObject.CompareTag("EnemyAI"))
            {
                MyEnemy enemy = nbObject.GetComponent<MyEnemy>();
                enemy.Hurt(_damage);
            }

        }
        Destroy(gameObject);
    }
}
