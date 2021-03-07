using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof (NavMeshAgent))]
public class EnemyController : MonoBehaviour
{

    bool isMoving = false;
    NavMeshAgent agent;
    public GameObject player;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position,player.transform.position) < 5) agent.destination = player.transform.position;
    }
}
