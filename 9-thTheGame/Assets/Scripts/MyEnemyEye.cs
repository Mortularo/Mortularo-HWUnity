using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MyEnemyEye : MonoBehaviour
{
    [Range(0, 360)] public float viewAngle = 90f;
    public float viewDistance = 15f;
    public float detectionDistance = 3f;
    public Transform _enemyEye;
    public Transform _target;
    //public NavMeshAgent _agent;
    private Transform _agentTransform;

    /*/
    void Start()
    {
        //_target = FindGameObjectWithTag("Player");
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agentTransform = _agent.transform;
    }*/

    
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(_target.transform.position, transform.position);
        if (distanceToPlayer <= detectionDistance || IsInView())
        {
            RotateToTarget();
        }
        DrawViewState();
    }

    private bool IsInView()
    {
        float realAngle = Vector3.Angle(_enemyEye.forward, _target.position - _enemyEye.position);
        RaycastHit hit;
        if(Physics.Raycast(_enemyEye.transform.position, _target.position - _enemyEye.position, out hit, viewDistance))
        {
            if (realAngle<viewAngle/2f && Vector3.Distance(_enemyEye.position, _target.position) <= viewDistance && hit.transform == _target.transform)
            {
                return true;
            }
        }
        return false;
    }
    private void RotateToTarget()
    { 
    
    }
    /*private void MoveToTarget()
    {
        _agent.SetDestination(_target.position);
    }*/
    private void DrawViewState()
    {
        Vector3 left = _enemyEye.position + Quaternion.Euler(new Vector3(0, viewAngle / 2F, 0)) * (_enemyEye.forward * viewDistance);
        Vector3 right = _enemyEye.position + Quaternion.Euler(-new Vector3(0, viewAngle / 2F, 0)) * (_enemyEye.forward * viewDistance);
        Debug.DrawLine(_enemyEye.position, left, Color.yellow);
        Debug.DrawLine(_enemyEye.position, right, Color.yellow);
    }
}
