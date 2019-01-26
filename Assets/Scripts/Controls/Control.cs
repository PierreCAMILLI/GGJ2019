using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : SingletonBehaviour<Control>
{
    [SerializeField]
    private List<PlayerControls> playerControls;

    public PlayerControls Player(int player = 0)
    {
        return playerControls[player];
    }
}
