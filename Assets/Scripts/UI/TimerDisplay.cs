using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{

    // Use this for initialization

    private float timer = 12;
    public Text TimerText;
    void Start()
    {

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
    }
}
