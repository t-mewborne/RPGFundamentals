using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float lifetime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Removeme",lifetime);
    }

    void Removeme() {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag=="Enemy") {
            collision.gameObject.GetComponent<EnemyController>().Kill();
            Debug.Log("ow");
            
        }
        Removeme();
    }
}
