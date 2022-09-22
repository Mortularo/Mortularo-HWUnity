using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.SceneManagement;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject _spawnPoint;
    public GameObject _enemy;
    private bool generate;
    private int x;


    void Start()
    {
        x = Random.Range(0, 2);
        if (x == 1)
        {
            Instantiate(_enemy, _spawnPoint.transform.position, Quaternion.identity);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
