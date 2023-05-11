using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICompanionState : AIState
{
    public override void EnterState(AIStateController AI)
    {
        Debug.Log("Companion State");

        //enables agent for AI companion when it enters state.
        //This is because when it leaves this state to go to pickup state, it is disabled.
        AI.agent.enabled = true;

        var cubeRenderer = AI.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.green);

        //Also is setting that the AI's rigidbody is kinematic when in companion state as this is set to not kinematic when in pickup state.
        if (AI.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = true;
        }
    }

    public override void UpdateState(AIStateController AI)
    {
        //This is to update the AI's follow position every frame as the player can possibly move every frame (if inputted wasd)
        AI.agent.SetDestination(AI.player.position);

        //This is checking for the left mouse button down. 0 is the number for the left button.
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Input.mousePosition;
            
            //Using Raycast to find out if the left click is in the right position over the companion object collider.
            Ray ray = Camera.main.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitData))
            {
                if (hitData.collider.TryGetComponent<AIStateController>(out AIStateController stateController))
                {
                    //If the raycast is in the correct position, it will then change the companion state to pick up state.
                    stateController.TransitionToState(stateController.pickupState); 
                }
            }
        }
    }

    public override void OnTriggerState(AIStateController AI, Collider collision)
    {
        //Checking if the trigger that kills the companions has the tag "DeathZone".
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            if (AI.player.TryGetComponent<CompanionCount>(out CompanionCount companionCount))
            {
                //This removes the companion that got killed from the companion count list.
                companionCount.RemoveSelfFromList(AI);
            }
            AI.TransitionToState(AI.enemyState);
        }
    }
    public override void OnCollisionState(AIStateController AI, Collision collision)
    {

    }
}

