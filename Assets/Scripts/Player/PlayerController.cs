using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private int playerNumber = 0;

    [SerializeField]
    private bool handleCameraOrientation = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleDirection();
        HandleInteraction();
    }

    void HandleDirection()
    {
        Vector2 dir = Control.Instance.Player(playerNumber).Direction;
        if (handleCameraOrientation)
        {
            player.SetDirection((Camera.main.transform.forward.X0Z() * dir.y) + (Camera.main.transform.right.X0Z() * dir.x));
        } else 
        {
            player.SetDirection(dir.XZ());
        }
    }

    void HandleInteraction()
    {
        if (Control.Instance.Player(playerNumber).InteractionDown)
        {
            player.Interact();
        }
    }
}
