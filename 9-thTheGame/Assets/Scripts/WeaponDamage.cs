using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    [SerializeField] private int _damage = 5;

    private void OnTriggerEnter(Collider col)
    { 
        if(col.gameObject.CompareTag("EnemyAI"))
        {
            MyEnemy enemy = col.GetComponent<MyEnemy>();
            enemy.Hurt(_damage);
        }
    }
    
    private void Start()
    {
        GetComponent<MeshCollider>().enabled = false;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GetComponent<MeshCollider>().enabled = true;

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            GetComponent<MeshCollider>().enabled = false;
        }
    }
}
