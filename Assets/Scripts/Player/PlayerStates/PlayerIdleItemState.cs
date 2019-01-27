using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleItemState", menuName = "Player States/Idle Item", order = 2)]
public class PlayerIdleItemState : PlayerIdleState
{
    public new void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public new void OnStateEnter()
    {
        base.OnStateEnter();
    }

    public new void OnStateExit()
    {
        base.OnStateExit();
    }

    public override void Update()
    {
        if (Player.Direction.sqrMagnitude > 0f)
        {
            StateMachine.SetState(Player.State.WalkItem);
        }
        if (Player.Item == ItemsEnum.Nothing)
        {
            StateMachine.SetState(Player.State.Idle);
        }
    }
}
