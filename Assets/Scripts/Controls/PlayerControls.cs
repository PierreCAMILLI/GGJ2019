using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerControls", menuName = "Player Controls", order = 0)]
public class PlayerControls : ScriptableObject
{
    [SerializeField]
    private string horizontalAxis = "Horizontal";
    [SerializeField]
    private string verticalAxis = "Vertical";

    [SerializeField]
    private KeyCode interaction = KeyCode.Joystick1Button0;

    [SerializeField]
    private KeyCode pause = KeyCode.Joystick1Button7;

    public float Horizontal
    {
        get { return Input.GetAxis(horizontalAxis); }
    }
    public float Vertical
    {
        get { return Input.GetAxis(verticalAxis); }
    }
    public Vector2 Direction
    {
        get { return new Vector2(Horizontal, Vertical); }
    }

    public bool Interaction
    {
        get { return Input.GetKey(interaction); }
    }
    public bool InteractionDown
    {
        get { return Input.GetKeyDown(interaction); }
    }
    public bool InteractionUp
    {
        get { return Input.GetKeyUp(interaction); }
    }

    public bool PauseDown
    {
        get { return Input.GetKeyDown(pause); }
    }
    public bool PauseUp
    {
        get { return Input.GetKeyUp(pause); }
    }
}
