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

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.W))
            move.SetTrigger("Walk");

        if (Input.GetKeyDown(KeyCode.R))
            move.SetTrigger("Run");

        if (Input.GetKeyDown(KeyCode.D))
            move.SetTrigger("Dead");*/

        //float speed = 10 * Time.deltaTime;
        //float xAxis = Input.GetAxis("Horizontal") * speed;
        //float zAxis = Input.GetAxis("Verticalk") * speed;
        //transform.position += new Vector3(xAxis, 0f, zAxis);

        if(navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            int rand = Random.Range(0, points.Length);
            navAgent.SetDestination(points[rand].position);
            ++pointCount;
            Debug.Log("Skeleton 1: Arrived! Point Count = " + pointCount);
        }

        if(pointCount == 10 && !navAgent.isStopped)
        {
            navAgent.isStopped = true;
            move.SetTrigger("Idle");
        }

    }
}

