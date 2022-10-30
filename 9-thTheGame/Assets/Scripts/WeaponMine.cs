using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class WeaponMine : MonoBehaviour
{
    public float _radius = 40f;
    public float _force = 500f;
    public int _damage = 30;

    public GameObject exposionEffect;

    bool hasExploded = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("EnemyAI") && !hasExploded)
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
