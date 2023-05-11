using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIState
{
    public abstract void EnterState(AIStateController AI);
    public abstract void UpdateState(AIStateController AI);
    public abstract void OnTriggerState(AIStateController AI, Collider collision);
    public abstract void OnCollisionState(AIStateController AI, Collision collision);
}
