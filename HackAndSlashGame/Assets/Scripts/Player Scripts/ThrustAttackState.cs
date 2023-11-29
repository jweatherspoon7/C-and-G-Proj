using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrustAttackState : BaseAttack
{
    public override void OnEnter()
    {
        stateName = "ThrustAttack";
        finisher = true;
        base.OnEnter();
    }

    public override void OnUpdate() { base.OnUpdate(); }

    public override void OnExit() { base.OnExit(); }
}
