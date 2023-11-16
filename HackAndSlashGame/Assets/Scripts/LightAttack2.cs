using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAttack2 : BaseAttack
{
    public override void OnEnter()
    {
        stateName = "LightAttack2";
        nextAttackState = new LightAttack3();
        base.OnEnter();
    }

    public override void OnUpdate() { base.OnUpdate(); }

    public override void OnExit() { base.OnExit(); }
}