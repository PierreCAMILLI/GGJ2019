using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{

    // Use this for initialization

    private float timer = 10;
    public Text timerText;
    
    public Color colorEndGame;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timerText.text = Mathf.RoundToInt(timer).ToString();
        if (timer <= 10)
        {
            timerText.color = colorEndGame;
        }
        
       
    }

    /*void SpawnEndScreen()
    {
        End_Screen.SetActive(true);
        EndScore.GetComponent<Text>().enabled = true;
    }*/
}
