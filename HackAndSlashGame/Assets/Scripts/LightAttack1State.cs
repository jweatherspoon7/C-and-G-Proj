using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1State : BaseAttack
{
    public override void OnEnter()
    {
        stateName = "LightAttack1State";
        nextAttackState = new LightAttack2State();
        base.OnEnter();
    }

    public override void OnUpdate(){ base.OnUpdate(); }

    public override void OnExit() { base.OnExit(); }
}
