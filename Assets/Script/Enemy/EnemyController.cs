using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void ChangeSpeed(float speed)
    {
        agent.speed = speed;
    }
    public void Move(Transform target)
    {
        agent.SetDestination(target.position);
    }
}