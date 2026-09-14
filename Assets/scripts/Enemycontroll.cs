using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using UnityEngine;
using UnityEngine.AI;
public class Enemycontroll : MonoBehaviour
{
    float speed = 1f;
    Rigidbody rb;
    NavMeshAgent agent;
    Animator anim;
    [SerializeField]
    List<Transform> Waypoint = new List<Transform>();
    [SerializeField]
    float waitTimeAtPoint = 2f;
    [SerializeField]
    bool patrolInLoop = true;

    int currentWaypointIndex = 0;
    bool iswaiting = false;
    bool movingForward = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        if (Waypoint == null || Waypoint.Count == 0) return;
        GoToCurrentWaypoint();
    }
    void Update()
    {
        if (Waypoint.Count == 0 || iswaiting) return;

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            anim.SetTrigger("Stop");
            SelectNextWayPoint();
            GoToCurrentWaypoint();
        }
    }
    void GoToCurrentWaypoint()
    {
        if (Waypoint.Count == 0) return;
        agent.SetDestination(Waypoint[currentWaypointIndex].position);
    }

    void SelectNextWayPoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % Waypoint.Count;
    }
    IEnumerator WaitAtWaypoint()
    {
        iswaiting = true;
        yield return new WaitForSeconds(waitTimeAtPoint);
        SelectNextWayPoint();
        anim.SetTrigger("Walk");
        agent.speed = speed;
        GoToCurrentWaypoint();
        iswaiting = false;
    }

    // Update is called once per frame
    //void Update()
    // {
    // Vector3 forwardMove = transform.forward * speed;
    // rb.linearVelocity = new Vector3(forwardMove.x, rb.linearVelocity.y, forwardMove.z);
    //}
}