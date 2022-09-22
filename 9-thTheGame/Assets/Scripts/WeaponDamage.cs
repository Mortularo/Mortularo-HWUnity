using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 5;

    // Update is called once per frame

    private void OnTriggerEnter(Collider col)
    { 
        if(col.gameObject.CompareTag("EnemyAI"))
        {
            MyEnemy enemy = col.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }
    }
    
}
