using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{

    public Transform pickupDestination;

    public bool mouseDown;

    public PlayerThrow throwScript;

    public AIStateController AIScript;

    // Start is called before the first frame update
    void Start()
    {
        mouseDown = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (mouseDown && AIScript.compPick)
        {
            GetComponent<Rigidbody>().useGravity = false;
            this.transform.position = pickupDestination.position;
            this.transform.parent = GameObject.Find("Destination").transform;
        }
        else if (!mouseDown && AIScript.compPick)
        {
            this.transform.parent = null;
            GetComponent<Rigidbody>().useGravity = true;
        }
    }

    void OnMouseDown()
    {
        if (AIScript.compPick == true)
        {
            Debug.Log("Click");
            mouseDown = true;
        }
        
    }

    public void OnMouseUp()
    {
        if (AIScript.compPick == true)
        {
            Debug.Log("UpClick");
            mouseDown = false;
            throwScript.Throw();
        }
        
    }
}
