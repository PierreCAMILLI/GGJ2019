using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerStateMachine
{
    private Player player;

    [SerializeField]
    private Player.State currentState;
    public Player.State State { get { return currentState; } }
    private Player.State nextState;

    [SerializeField]
    private PlayerState[] states;
    Dictionary<Player.State, PlayerState> mapStates;

    public void FillStates(Player player)
    {
        PlayerState.Initializer init = new PlayerState.Initializer
        {
            stateMachine = this,
            player = player
        };

        mapStates = new Dictionary<Player.State, PlayerState>();
        foreach(PlayerState state in states)
        {
            PlayerState newState = Object.Instantiate(state) as PlayerState;
            newState.Initialize(init);
            mapStates.Add(state.State, newState);
        }
        nextState = currentState;
        mapStates[currentState].OnStateEnter();
    }

    public void SetState(Player.State state)
    {
        nextState = state;
    }

    // Update is called once per frame
    public void Update()
    {
        if (nextState != currentState)
        {
            mapStates[currentState].OnStateExit();
            mapStates[nextState].OnStateEnter();
            currentState = nextState;
        }
        mapStates[currentState].Update();
    }

    public void FixedUpdate()
    {
        mapStates[currentState].FixedUpdate();
    }
}
