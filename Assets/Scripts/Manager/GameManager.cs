using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonBehaviour<GameManager>
{
    public enum State
    {
        MainMenu,
        StartingCounter,
        Game,
        StopMessage,
        Score
    }

    #region Serialized Fields
    [SerializeField]
    private float startCounterDuration = 3f;
    #endregion

    #region Game Parameters
    public struct Initializer
    {
        public float gameDuration;
        public int playersNumber;
    }

    [SerializeField]
    private float gameDuration = 120f;
    [SerializeField]
    [Range(1,4)]
    private int playersNumber = 1;
    #endregion

    #region Game Infos
    [SerializeField]
    private State gameState;
    public State GameState
    {
        get { return gameState; }
    }

    private float startCounter;

    private float gameTimer;
    public float RemainingTime
    {
        get { return gameDuration - gameTimer; }
    }
    private bool timerActive;
    private int[] playersScore;
    public int[] PlayersScore
    {
        get { return playersScore; }
    }
    #endregion

    private void Update()
    {
        switch (gameState)
        {
            case State.MainMenu:
                break;
            case State.StartingCounter:
                startCounter += Time.deltaTime;
                if(startCounterDuration <= startCounter)
                {
                    SetGameState(State.Game);
                }
                break;
            case State.Game:
                if (timerActive)
                {
                    gameTimer = Mathf.Clamp(gameTimer + Time.deltaTime, 0f, gameDuration);
                }
                if (RemainingTime == 0f)
                {
                    SetGameState(State.StopMessage);
                }
                break;
            case State.StopMessage:
                break;
            case State.Score:
                break;
        }
    }

    public void ToggleTimer(bool toggle)
    {
        timerActive = toggle;
    }

    public void SetGameParameters(Initializer initializer)
    {
        playersNumber = initializer.playersNumber;
        playersScore = new int[playersNumber];
    }

    public void SetGameState(State state)
    {
        gameState = state;
        Debug.Log(state.ToString());

        switch (state)
        {
            case State.MainMenu:
                break;
            case State.StartingCounter:
                startCounter = 0f;
                gameTimer = 0f;
                // TEMP
                SetGameParameters(new Initializer
                {
                    gameDuration = 120f,
                    playersNumber = 1
                });
                LevelGenerator.Instance.GenerateMap();
                break;
            case State.Game:
                break;
            case State.StopMessage:
                break;
            case State.Score:
                break;
        }
    }
}
