using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack1 : BaseAttack
{
    public override void OnEnter()
    {
        stateName = "LightAttack1";
        nextAttackState = new LightAttack2();
        base.OnEnter();
    }

    public override void OnUpdate(){ base.OnUpdate(); }

    public override void OnExit() { base.OnExit(); }
}
