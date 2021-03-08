using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationHandler : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    //public bool canWalk = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = agent.velocity.magnitude>0;
        animator.SetBool("isMoving",isWalking);
    }

    public void fireWeapon() {
        //animator.SetBool("isShooting",true);
    }

    public void pickUp() {
        //animator.SetBool("pickup",true);
        animator.SetTrigger("pickup");
    }

    public void Death() {
        animator.SetBool("dead",true);
    }
}
