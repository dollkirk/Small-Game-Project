using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyMove : MonoBehaviour
{

    //This is the maths of where the enemy AI needs to patrol next when it has collided with the patrol point.
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<AIStateController>(out AIStateController stateController))
        {
            var targetPosition = stateController.SetNextTarget();

            //Check nextTarget is its current position
            var x = Mathf.Approximately(transform.position.x, targetPosition.x);
            var z = Mathf.Approximately(transform.position.z, targetPosition.z);
            if (x && z)
            {
                stateController.SetNextTarget();
            }
        }
    }
}
