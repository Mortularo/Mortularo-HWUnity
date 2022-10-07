using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chaseBehav : StateMachineBehaviour
{
    NavMeshAgent agent;
    Transform player;
    float attackRange = 2f;
    float chaseRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.speed = 2;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(player.position);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if(distance <= attackRange)
        {
            animator.SetBool("isAttaking", true);
        }
        if (distance > chaseRange)
        {
            animator.SetBool("isChasing", false);
        }
    }
       
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
        agent.speed = 1;
    }

}
