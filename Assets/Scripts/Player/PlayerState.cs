using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState : ScriptableObject
{
    [SerializeField]
    private Player.State state;
    public Player.State State { get { return state; } }

    public struct Initializer
    {
        public PlayerStateMachine stateMachine;
        public Player player;
    }
    protected PlayerStateMachine StateMachine { get; private set; }
    protected Player Player { get; private set; }

    public void Initialize(Initializer initializer)
    {
        StateMachine = initializer.stateMachine;
        Player = initializer.player;
    }

    // Start is called before the first frame update
    abstract public void OnStateEnter();

    // Update is called once per frame
    public abstract void Update();

    public abstract void FixedUpdate();

    public abstract void OnStateExit();
}
