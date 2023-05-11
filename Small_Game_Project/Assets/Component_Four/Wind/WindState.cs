using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WindState
{
    public abstract void EnterState(WindStateController wind);
    public abstract void UpdateState(WindStateController wind);
}
