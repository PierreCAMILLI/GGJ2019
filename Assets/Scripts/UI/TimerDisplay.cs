using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    private float timer = 10;
    public Text timerText;
    
    public Color colorEndGame;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer = GameManager.Instance.RemainingTime;
        timerText.text = Mathf.CeilToInt(timer).ToString();
        if (timer <= 10)
        {
            timerText.color = colorEndGame;
        } else
        {
            timerText.color = Color.black;
        }
        
       
    }

    /*void SpawnEndScreen()
    {
        End_Screen.SetActive(true);
        EndScore.GetComponent<Text>().enabled = true;
    }*/
}
