using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    private Player player;

    [SerializeField]
    private GameObject broom;

    [SerializeField]
    private ParticleSystem cleaningParticles;

    // Update is called once per frame
    void Update()
    {
        if (    (player.StateMachine.State == Player.State.Walk
            ||  player.StateMachine.State == Player.State.WalkItem)
            &&  player.Direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(player.Direction, Vector3.up);
        }
        cleaningParticles.gameObject.SetActive(player.StateMachine.State == Player.State.Cleaning) ;
        broom.SetActive(player.Item != ItemsEnum.Nothing);
    }
}
