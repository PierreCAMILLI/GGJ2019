﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD : SingletonBehaviour<HUD>
{
    [SerializeField]
    private RectTransform startingCounter;
    public RectTransform StartingCounter
    {
        get { return startingCounter; }
    }

    [SerializeField]
    private RectTransform stopCleaning;
    public RectTransform StopCleaning
    {
        get { return stopCleaning; }
    }

    [SerializeField]
    private RectTransform score;
    public RectTransform Score
    {
        get { return score; }
    }

}
