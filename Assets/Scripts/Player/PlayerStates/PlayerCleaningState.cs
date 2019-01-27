using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CleaningState", menuName = "Player States/Cleaning", order = 5)]
public class PlayerCleaningState : PlayerState
{
    private float timeStartCleaning;

    public override void FixedUpdate()
    {
    }

    public override void OnStateEnter()
    {
        timeStartCleaning = Time.time;
    }

    public override void OnStateExit()
    {
    }

    public override void Update()
    {
        if (Time.time > (timeStartCleaning + Player.CleaningTime))
        {
            Player.HandlingDisposable.Dispose(Player);
            StateMachine.SetState((Player.Item != ItemsEnum.Nothing) ? Player.State.IdleItem : Player.State.Idle);
        }
    }
}
