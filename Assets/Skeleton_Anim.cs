using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Skeleton_Anim : MonoBehaviour
{

    public Animator move;
    public NavMeshAgent navAgent;
    public Transform[] points;
    private int pointCount;

    // Start is called before the first frame update
    void Start()
    {
        int rand = Random.Range(0, points.Length);
        navAgent.SetDestination(points[rand].position);
        move.SetTrigger("Walk");
    }

    void Update()
    {
        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int rand = Random.Range(0, points.Length);
            navAgent.SetDestination(points[rand].position);
            ++pointCount;
            Debug.Log("Skeleton: Arrived On Point = " + pointCount);
        }

        if(pointCount == 30 && !navAgent.isStopped)
        {
            navAgent.isStopped = true;
            move.SetTrigger("Idle");
        }

    }
}

