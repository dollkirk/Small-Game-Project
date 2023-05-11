using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIStateController : MonoBehaviour
{
    [HideInInspector] public NavMeshAgent agent;
    [HideInInspector] public Vector3 target;
    private int direction = 1;
    private int targetIndex = 0;
    [HideInInspector] public Transform player;

    
    public AIEnemyMove[] points;

    public AIState currentState { get; private set; }

    public readonly AIEnemyState enemyState = new AIEnemyState();
    public readonly AICompanionState companionState = new AICompanionState();
    public readonly PickupState pickupState = new PickupState();


    public bool compPick = false;


    public PlayerThrow throwScript;



    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //The AI should be in enemy state to start with.
        TransitionToState(enemyState);

        player = GameObject.FindWithTag("Player").transform;

        //Finding the positions of the points of patrolling for the AI.
        if (points.Length > 0)
        {
            target = points[targetIndex].transform.position;
        }
    }

    void Update()
    {
        currentState.UpdateState(this);
    }

    //This function is calculating where the AI needs to go next in the array of points. Therefore, if I add anymore points that the AI needs to patrol, it will work.
    public Vector3 SetNextTarget()
    {
        targetIndex += direction;
        if (targetIndex == points.Length)
        {
            direction = -1;
            targetIndex = points.Length - 2;
        }
        else if (targetIndex < 0)
        {
            direction = 1;
            targetIndex = 1;
        }
        target = points[targetIndex].transform.position;
        return target;
    }

    //This is a Unity method that is checking if the AI triggers any colliders set as triggers.
    private void OnTriggerEnter(Collider collision)
    {
        currentState.OnTriggerState(this, collision);
    }

    //This is a Unity method that is checking if the AI collides with anything.
    private void OnCollisionEnter(Collision Oncollision)
    {
        currentState.OnCollisionState(this, Oncollision);
    }

    //This method changes the state to whatever is in the parenthesis.
    public void TransitionToState(AIState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }

    //This is a Unity mothod that does whatever is in it when the left mouse button is lifted.
    public void OnMouseUp()
    {
        //Checking if the current state of the companion is the pickup state.
        if (currentState == pickupState)
        {
            //Calls the Throw() function that is in the "PlayerThrow" script.
            throwScript.Throw();
        }
    }
}
