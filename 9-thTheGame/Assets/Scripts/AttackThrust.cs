using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackThrust : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            gameObject.GetComponent<Animator>().SetTrigger("Grenade");
        }
    }
}
