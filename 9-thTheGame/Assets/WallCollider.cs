using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WallCollider : MonoBehaviour
{
    List<Transform> points = new List<Transform>();
    NavMeshAgent _agent;
    public bool gotCollide = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void OnCollisionStart(Collision collision, Animator animator)
    {
        Transform pointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        if (collision.gameObject.tag == "Walls" || collision.gameObject.tag == "EnemyAI")
        {
            _agent = animator.GetComponent<NavMeshAgent>();
            _agent.SetDestination(points[Random.Range(0, points.Count)].position);
            gotCollide = true;
        }
    }
}
