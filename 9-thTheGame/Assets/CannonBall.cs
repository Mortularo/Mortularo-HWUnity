using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float timer = 5f;
    private void Awake()
    {
        Destroy(gameObject, timer);
    }
}
