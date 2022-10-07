using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float timer = 5f;
    [SerializeField] private int _damage = 1;
   
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            //MyEnemy enemy = col.GetComponent<MyEnemy>();
            //enemy.Hurt(_damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, timer);
        }
    }

    /*private void Awake()
    {
        Destroy(gameObject, timer);
    }*/


}
