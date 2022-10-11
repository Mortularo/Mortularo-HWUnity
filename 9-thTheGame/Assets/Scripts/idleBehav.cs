using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBehav : StateMachineBehaviour
{
    float timer;
    Transform player;
    float chaseRange = 10f;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (timer > Random.Range(5, 40))
        {
            animator.SetBool("onPatrol", true);
        }
        
        float distance = Vector3.Distance(animator.transform.position, player.position);
        
        if (distance <= chaseRange)
        {
            animator.SetBool("isChasing", true);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }


}
