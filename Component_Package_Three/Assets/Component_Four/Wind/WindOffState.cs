using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOffState : WindState
{
    public override void EnterState(WindStateController wind)
    {

    }

    public override void UpdateState(WindStateController wind)
    { 
        Debug.Log("wind off");
    }

    public void Destroyed(WindState newState, WindStateController state)
    {
        state.TransitionToState(newState);
    }
}
