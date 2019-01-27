using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkItemState", menuName = "Player States/Walk Item", order = 3)]
public class PlayerWalkItemState : PlayerWalkState
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

        if (Player.Direction.sqrMagnitude == 0f)
        {
            StateMachine.SetState(Player.State.IdleItem);
        }
        if (Player.Item == ItemsEnum.Nothing)
        {
            StateMachine.SetState(Player.State.Walk);
        }
    }
}

