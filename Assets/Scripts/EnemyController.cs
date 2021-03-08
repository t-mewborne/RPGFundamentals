using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof (NavMeshAgent))]
public class EnemyController : MonoBehaviour
{

    bool isAlive = true;
    public GameObject player;
    public GameObject rewardObject;

    NavMeshAgent agent;
    AnimationHandler animator;

    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<AnimationHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive && Vector3.Distance(transform.position,player.transform.position) < 5) agent.destination = player.transform.position;
    }

    public void Kill()
    {
        animator.Death();
        isAlive=false;
        Invoke("Remove",5f);
    }

    public void Remove()
    {
        Instantiate(rewardObject,transform.position,transform.rotation);
        Destroy(gameObject);
    }

}
