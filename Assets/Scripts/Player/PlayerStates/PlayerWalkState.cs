using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WalkState", menuName = "Player States/Walk", order = 1)]
public class PlayerWalkState : PlayerState
{
    public override void FixedUpdate()
    {
        Player.Rigidbody.MovePosition(Player.Rigidbody.position + (Player.Direction * Time.fixedDeltaTime * Player.Speed));
    }

    public override void OnStateEnter()
    {
    }

    public override void OnStateExit()
    {
    }

    public override void Update()
    {
        if (Player.Direction.sqrMagnitude == 0f)
        {
            StateMachine.SetState(Player.State.Idle);
        }
        if (Player.Item != ItemsEnum.Nothing)
        {
            StateMachine.SetState(Player.State.WalkItem);
        }
    }
}
