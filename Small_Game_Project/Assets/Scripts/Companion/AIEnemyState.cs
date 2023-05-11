using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemyState : AIState
{
    public override void EnterState(AIStateController AI)
    {
        Debug.Log("EnemyState");
        var cubeRenderer = AI.GetComponent<Renderer>();
        cubeRenderer.material.SetColor("_Color", Color.red);
    }

    public override void UpdateState(AIStateController AI)
    {
        AI.agent.SetDestination(AI.target);
    }

    public override void OnTriggerState(AIStateController AI, Collider collision)
    {
        //Checking if the trigger collider is on the game object with the tag "Player".
        if (collision.gameObject.CompareTag("DestroyEnemy"))
        {
            AI.TransitionToState(AI.companionState);
        }
    }

    public override void OnCollisionState(AIStateController AI, Collision collision)
    {

    }
}
