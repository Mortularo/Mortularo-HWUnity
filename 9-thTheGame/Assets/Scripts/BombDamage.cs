using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BombDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 30;
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("EnemyAI"))
        {
            MyEnemy enemy = col.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
        }
    }
}
