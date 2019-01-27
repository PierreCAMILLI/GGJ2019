﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    public void OnSelect(Interactable.Interaction interaction)
    {
        if (interaction.player.Item == ItemsEnum.Nothing)
        {
            interaction.player.Item = ItemsEnum.Vacuum;
            Destroy(gameObject);
        }
    }
}
