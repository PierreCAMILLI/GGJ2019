using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour
{
    public void OnSelect(Interactable.Interaction interaction)
    {
        if (interaction.player.Item == ItemsEnum.Nothing)
        {
            interaction.player.Item = ItemsEnum.Broom;
            Destroy(gameObject);
        }
    }
}
