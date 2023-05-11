using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    [Header("References")]
    public Transform playerRotation;
    //public Transform throwPoint;
    //public GameObject throwableObject;

    [Header("Throwing")]
    public int totalThrows;
    public float throwCoolDown;
    public float throwForce;
    public float throwUpwardForce;

    //private bool readyToThrow;


    public void Throw()
    {
        if (TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            Debug.Log("Thrown");
            rb.isKinematic = false;
            transform.parent = null;
            Vector3 forceToAdd = (playerRotation.transform.forward * throwForce) + (rb.transform.up * throwUpwardForce);

            rb.AddForce(forceToAdd, ForceMode.Impulse);
        }
    }

    
}
