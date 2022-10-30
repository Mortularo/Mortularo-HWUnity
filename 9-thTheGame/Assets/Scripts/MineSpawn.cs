using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSpawn : MonoBehaviour
{
    public GameObject minePrefab;
    public Transform mineSpawn;


    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            PlantMine();
        }
    }
    private void PlantMine()
    {
        GameObject mine = Instantiate(minePrefab, mineSpawn.position, mineSpawn.rotation);
    }
}
