using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryCanvas : MonoBehaviour
{
    public PlayerControls player;
    private Canvas CanvasObject;
    public TMP_Text bulletCount; 
    // Start is called before the first frame update
    void Start()
    {
        CanvasObject = GetComponent<Canvas> ();
        CanvasObject.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.I)) 
         {
             CanvasObject.enabled = !CanvasObject.enabled;
         }
        bulletCount.text = "x"+player.ammo;

    }
}
