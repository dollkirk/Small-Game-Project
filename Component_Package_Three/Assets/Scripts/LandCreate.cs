using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandCreate : MonoBehaviour
{
    public Rigidbody companion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Reachable"))
        {
            companion = GetComponent<Rigidbody>();
            companion.constraints = RigidbodyConstraints.FreezeAll;
            companion.transform.localScale = new Vector3(2.5f,1,2.5f);
        }
    }
}
