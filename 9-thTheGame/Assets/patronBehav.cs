using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class patronBehav : StateMachineBehaviour
{
    float timer;
    List<Transform> points = new List<Transform>();
    NavMeshAgent _agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        Transform pointsObject = GameObject.FindGameObjectWithTag("WayPoints").transform;
        foreach (Transform t in pointsObject)
        {
            points.Add(t);
        }
        _agent = animator.GetComponent<NavMeshAgent>();
        _agent.SetDestination(points[Random.Range(0, points.Count)].position);

    }



    override public void OnStateUpdate( Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _agent.SetDestination(points[Random.Range(0, points.Count)].position);

        }

        timer += Time.deltaTime;
        if (timer > Random.Range(10, 50))
        {
            animator.SetBool("onPatrol", false);
        }
    }

    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _agent.SetDestination(_agent.transform.position);
    }
    


}
