using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof (NavMeshAgent))]
public class PlayerControls : MonoBehaviour
{
    RaycastHit hitInfo  = new RaycastHit();
    NavMeshAgent agent;
    AnimationHandler animator;
    public GameObject bullet;
    Camera mainCamera;

    public int ammo;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<AnimationHandler>();
        mainCamera = Camera.main;
        ammo = 100;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPosition = new Vector3(transform.position.x,transform.position.y+4.2f,transform.position.z-9.31f);
        mainCamera.transform.position=cameraPosition;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin,ray.direction,out hitInfo)) {
                agent.destination = transform.position;
                //animator.canWalk=true;
                //agent.updatePosition=true;
                agent.destination=hitInfo.point;
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin,ray.direction,out hitInfo)) {
                GameObject newProjectile = Instantiate(bullet,transform.position,transform.rotation);
                newProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward*40);
                ammo--;

            }
        }
    }
}
