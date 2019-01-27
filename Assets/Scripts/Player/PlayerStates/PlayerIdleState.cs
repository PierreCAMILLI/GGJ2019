using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "Player States/Idle", order = 0)]
public class PlayerIdleState : PlayerState
{
    public override void FixedUpdate()
    {
        Player.Rigidbody.velocity = Vector3.zero;
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }

    public override void Update()
    {
        if (Player.Direction.sqrMagnitude > 0f)
        {
            StateMachine.SetState(Player.State.Walk);
        }
        if (Player.Item != ItemsEnum.Nothing)
        {
            StateMachine.SetState(Player.State.IdleItem);
        }
    }
}
