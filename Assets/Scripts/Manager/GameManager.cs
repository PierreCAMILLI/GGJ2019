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
        Score,
        DebugMode
    }

    #region Serialized Fields
    [SerializeField]
    private float startCounterDuration = 3f;
    public float StartCounterDuration
    {
        get { return startCounterDuration; }
    }

    [SerializeField]
    private float stopDuration = 3f;
    public float StopDuration
    {
        get { return stopDuration; }
    }
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
    public int PlayersNumber
    {
        get { return playersNumber; }
    }
    #endregion

    #region Game Infos
    [SerializeField]
    private State gameState;
    public State GameState
    {
        get { return gameState; }
    }

    private float startCounter;
    public float StartCounter
    {
        get { return startCounter; }
    }

    private float stopCounter;
    public float StopCounter
    {
        get { return stopCounter; }
    }

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

    private void Start()
    {
        SetGameState(gameState);
    }

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
                stopCounter += Time.deltaTime;
                if (stopDuration <= stopCounter)
                {
                    SetGameState(State.Score);
                }
                break;
            case State.Score:
                break;
            case State.DebugMode:
                break;
        }
    }

    public void ToggleTimer(bool toggle)
    {
        timerActive = toggle;
    }

    public void SetGameParameters(Initializer initializer)
    {
        gameDuration = initializer.gameDuration;
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
                HUD.Instance.StartingCounter.gameObject.SetActive(true);
                HUD.Instance.StopCleaning.gameObject.SetActive(false);
                HUD.Instance.Score.gameObject.SetActive(false);

                startCounter = 0f;
                gameTimer = 0f;
                // TEMP
                SetGameParameters(new Initializer
                {
                    gameDuration = 60f,
                    playersNumber = 2
                });
                LevelGenerator.Instance.GenerateMap();
                break;
            case State.Game:
                HUD.Instance.StartingCounter.gameObject.SetActive(false);

                timerActive = true;
                break;
            case State.StopMessage:
                HUD.Instance.StopCleaning.gameObject.SetActive(true);

                stopCounter = 0f;
                break;
            case State.Score:
                HUD.Instance.StopCleaning.gameObject.SetActive(false);
                HUD.Instance.Score.gameObject.SetActive(true);
                break;
            case State.DebugMode:
                playersScore = new int[playersNumber];
                break;
        }
    }

    public void RestartGame()
    {
        SetGameState(State.StartingCounter);
    }

    public void BackToMenu()
    {
        SetGameState(State.MainMenu);
    }
}
