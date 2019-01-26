using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{

    // Use this for initialization

    private float timer = 1;
    public Text TimerText;
    public GameObject Stop_Cleaning;
    public GameObject End_Screen;
    public Text EndScore;

    void Start()
    {
        Stop_Cleaning.SetActive(false);
        End_Screen.SetActive(false);
        EndScore.GetComponent<Text>().enabled = false;
        EndScore.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        TimerText.text = Mathf.RoundToInt(timer).ToString();
        if (timer <= 10)
        {
            TimerText.color = Color.red;
        }

        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Stop_Cleaning.SetActive(true);
            Invoke("SpawnEndScreen", 1);
        }
    }

    void SpawnEndScreen()
    {
        End_Screen.SetActive(true);
        EndScore.GetComponent<Text>().enabled = true;
    }
}
