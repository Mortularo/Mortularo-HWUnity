using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretHealth : MonoBehaviour
{
    [SerializeField] private int health = 40;

    internal void Hurt(int damage)
    {
        Debug.Log(message: "Hit :" + damage);
        health -= damage;
        gameObject.GetComponent<Animator>().SetTrigger("gotDamage");
        if (health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        //gameObject.GetComponent<Animator>().SetTrigger("Destroyed");
        Destroy(gameObject, 30f);
    }
}
