using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MyEnemy : MonoBehaviour
    {
        [SerializeField] private int health = 15;

        internal void Hurt(int damage)
        {
            Debug.Log(message:"Hit :"+damage);
            health -= damage;
            gameObject.GetComponent<Animator>().SetTrigger("gotDamage");
            if (health <=0)
            {
                Die();
            }
        }
        public void Die()
        {
            Destroy(gameObject);
        }

    }
}