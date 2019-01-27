using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    #region Sounds
    [Header("Sounds")]
    [SerializeField]
    private AudioClip MainMusic;
    [SerializeField]
    private AudioClip FinalSound;
    #endregion


    #region Game Parameters
    
    public struct Initializer
    {
        public float gameDuration;
        public int playersNumber;
    }
    [Header("Parameters")]
    [SerializeField]
    private float gameDuration = 60f;
    [SerializeField]
    [Range(1,4)]
    private int playersNumber = 1;
    public int PlayersNumber
    {
        get { return playersNumber; }
    }
    #endregion

    #region Game Infos
    [Header("Infos")]
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

    private AudioSource AudioPlayer;
    #endregion

    #region Prefabs to Spawn
    [Header("Prefabs to spawn")]
    [SerializeField]
    private PointsNotification pointsNotificationPrefab;
    #endregion

    private void Start()
    {
        AudioPlayer = GetComponent<AudioSource>();
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
                Menu.Instance.MainMenu.gameObject.SetActive(true);
                Menu.Instance.OptionMenu.gameObject.SetActive(false);
                Menu.Instance.CreditsMenu.gameObject.SetActive(false);

                HUD.Instance.Icon.gameObject.SetActive(false);
                HUD.Instance.Clock.gameObject.SetActive(false);
                HUD.Instance.Timer.gameObject.SetActive(false);
                HUD.Instance.StartingCounter.gameObject.SetActive(false);
                HUD.Instance.StopCleaning.gameObject.SetActive(false);
                HUD.Instance.Score.gameObject.SetActive(false);
                break;
            case State.StartingCounter:
                Menu.Instance.MainMenu.gameObject.SetActive(false);
                Menu.Instance.OptionMenu.gameObject.SetActive(false);

                HUD.Instance.Icon.gameObject.SetActive(true);
                HUD.Instance.Clock.gameObject.SetActive(true);
                HUD.Instance.Timer.gameObject.SetActive(true);
                HUD.Instance.StartingCounter.gameObject.SetActive(true);
                HUD.Instance.StopCleaning.gameObject.SetActive(false);
                HUD.Instance.Score.gameObject.SetActive(false);
                
                startCounter = 0f;
                gameTimer = 0f;
                // TEMP
                /*SetGameParameters(new Initializer
                {
                    gameDuration = 120f,
                    gameDuration = 5f,
                    playersNumber = 1
                });*/
                playersScore = new int[playersNumber];
                LevelGenerator.Instance.GenerateMap();
                break;
            case State.Game:
                HUD.Instance.StartingCounter.gameObject.SetActive(false);

                AudioPlayer.loop = true;
                AudioPlayer.clip = MainMusic;
                AudioPlayer.Play();
                
                timerActive = true;
                break;
            case State.StopMessage:
                HUD.Instance.StopCleaning.gameObject.SetActive(true);

                stopCounter = 0f;

                AudioPlayer.loop = false;
                AudioPlayer.clip = FinalSound;
                AudioPlayer.Play();
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

    public void LaunchGame()
    {
        SetGameState(State.StartingCounter);
    }

    public void BackToMenu()
    {
        SetGameState(State.MainMenu);
    }

    public void DisplayOptions()
    {
        Menu.Instance.OptionMenu.gameObject.SetActive(true);
        Menu.Instance.MainMenu.gameObject.SetActive(false);
        Debug.Log("Options");
    }

    public void DisplayCredits()
    {
        Menu.Instance.CreditsMenu.gameObject.SetActive(true);
        Menu.Instance.MainMenu.gameObject.SetActive(false);
    }

    public void BackToMainMenuOptions()
    {
        Menu.Instance.OptionMenu.gameObject.SetActive(false);
        Menu.Instance.MainMenu.gameObject.SetActive(true);
    }

    public void BackToMainMenuCredits()
    {
        Menu.Instance.CreditsMenu.gameObject.SetActive(false);
        Menu.Instance.MainMenu.gameObject.SetActive(true);
    }

    public void Set2players()
    {
        playersNumber = 2;
    }

    public void Set1player()
    {
        playersNumber = 1;
    }

    public void SetGameDuration(int duration)
    {
        gameDuration = duration;
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Coucou");
    }

    public void SpawnPointsNotification(Vector3 position, int points)
    {
        PointsNotification pointsNotification = Instantiate(pointsNotificationPrefab, position, Quaternion.identity) as PointsNotification;
        pointsNotification.SetPoints(points);
        pointsNotification.Play();
    }
}
