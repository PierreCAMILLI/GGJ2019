using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartingCounter : MonoBehaviour
{
    Text counterText; 

    // Start is called before the first frame update
    void Start()
    {
        counterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        counterText.text = Mathf.CeilToInt(GameManager.Instance.StartCounterDuration - GameManager.Instance.StartCounter).ToString();
    }
}
