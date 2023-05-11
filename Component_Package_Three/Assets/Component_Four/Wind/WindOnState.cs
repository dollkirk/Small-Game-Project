using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindOnState : WindState
{
    public override void EnterState(WindStateController wind)
    {
        wind.windSpeed *= -1;
    }

    public override void UpdateState(WindStateController wind)
    {
        Debug.Log("Wind On");
        wind.ApplyForce();
    }

    public void Destroyed(WindState newState, WindStateController state)
    {
        state.TransitionToState(newState);
    }
}