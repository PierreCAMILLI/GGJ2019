using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private int pointsEarnedOnClean;

    public void OnInteract(Interactable.Interaction interaction)
    {
        switch (interaction.player.Item)
        {
            case ItemsEnum.Vacuum:
            case ItemsEnum.Broom:
                GameManager.Instance.PlayersScore[interaction.player.PlayerNumber] += pointsEarnedOnClean;
                interaction.player.Item = ItemsEnum.Nothing;
                Destroy(gameObject);
                break;
        }
    }
}
