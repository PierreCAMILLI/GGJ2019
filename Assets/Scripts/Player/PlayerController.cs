﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    public int PlayerNumber { get; set; }

    [SerializeField]
    private bool handleCameraOrientation = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player.PlayerNumber = PlayerNumber;
        HandleDirection();
        HandleInteraction();
    }

    void HandleDirection()
    {
        Vector2 dir = Control.Instance.Player(PlayerNumber).Direction;
        if (handleCameraOrientation)
        {
            player.SetDirection((Camera.main.transform.forward.X0Z().normalized * dir.y) + (Camera.main.transform.right.X0Z().normalized * dir.x));
        } else 
        {
            player.SetDirection(dir.XZ());
        }
    }

    void HandleInteraction()
    {
        if (Control.Instance.Player(PlayerNumber).InteractionDown)
        {
            player.Interact();
        }
    }
}
