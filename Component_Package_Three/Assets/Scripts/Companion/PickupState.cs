using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupState : AIState
{
    public override void EnterState(AIStateController AI)
    {
        Debug.Log("Pickup State");

        //Finds the game object named "Destination" in the scene and sets the variable t to the transform of "Destination".
        Transform t = GameObject.Find("Destination").transform;


        AI.transform.parent = t;

        //Freezes the position of the gameobject to (0, 0, 0).
        AI.transform.localPosition = new Vector3(0,0,0);

        //Disables the agent as the gameobject will not pickup otherwise.
        AI.agent.enabled = false;
    }

    public override void UpdateState(AIStateController AI)
    {
    }
    public void Destroyed(AIState newState, AIStateController state)
    {
        state.TransitionToState(newState);
    }

    public override void OnTriggerState(AIStateController AI, Collider collision)
    {

    }

    public override void OnCollisionState(AIStateController AI, Collision collision)
    {
        //Checking if the collision object has the tag named "Ground".
        if (collision.gameObject.CompareTag("Ground"))
        {
            AI.TransitionToState(AI.companionState);
        }
    }
}