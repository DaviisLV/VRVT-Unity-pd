
using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class Patrol : MonoBehaviour
{

    public Transform[] points;
    private NavMeshAgent agent;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;

        GotoNextPoint();
    }


    void GotoNextPoint()
    {

        if (points.Length == 0)
            return;

        agent.destination = points[(int)Random.Range(0, points.Length)].position;



    }


    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
            GotoNextPoint();
    }
}