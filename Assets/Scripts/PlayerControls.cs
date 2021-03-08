using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 using UnityEngine.SceneManagement;

[RequireComponent(typeof (NavMeshAgent))]
public class PlayerControls : MonoBehaviour
{
    RaycastHit hitInfo  = new RaycastHit();
    NavMeshAgent agent;
    AnimationHandler animator;
    public GameObject bullet;
    Camera mainCamera;
    GameObject pickupItem;
    public GameObject pickupItemParent;


    public int ammo;
    public int cubes;

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
                agent.destination=hitInfo.point;
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 bulletPosition = new Vector3(transform.position.x,transform.position.y+1f,transform.position.z);
            if (ammo > 0 && Physics.Raycast(ray.origin,ray.direction,out hitInfo)) {
                GameObject newProjectile = Instantiate(bullet,bulletPosition,transform.rotation);
                newProjectile.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.forward*40);
                ammo--;

            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            pickUp();
        }
    }


    bool pickUp() {
        bool itemInRange = pickupItem!=null;
        if (itemInRange) {
            animator.pickUp();
            Invoke("grab",2f);
        }
        return itemInRange;
    }

    void grab() {
        pickupItem.transform.parent=pickupItemParent.transform;
        pickupItem.transform.position = new Vector3(0f,0f,0f);
        pickupItem.transform.eulerAngles = new Vector3(0f,0f,0f);
        Invoke("addToInventory",2f);
    }

    void addToInventory() {
        Destroy(pickupItem);
        cubes++;
        if (cubes==2) SceneManager.LoadScene("End");
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag=="Pickupable"){
            pickupItem=collision.gameObject;
        }
    }

    void OnTriggerExit(Collider collision) {
        if (collision.gameObject.tag=="Pickupable"){
            pickupItem=null;
        }
    }


}
