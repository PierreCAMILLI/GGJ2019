using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Disposable
{
    void Dispose(Player player);
}

public class Dust : MonoBehaviour, Disposable
{
    [SerializeField]
    private int pointsEarnedOnClean;

    private bool isDisposing = false;

    public void OnInteract(Interactable.Interaction interaction)
    {
        if (!isDisposing)
        {
            switch (interaction.player.Item)
            {
                case ItemsEnum.Vacuum:
                case ItemsEnum.Broom:
                    isDisposing = true;
                    interaction.player.CleaningTime = 2f;
                    interaction.player.HandlingDisposable = this;
                    interaction.player.StateMachine.SetState(Player.State.Cleaning);
                    break;
            }
        }
    }

    public void Dispose(Player player)
    {
        GameManager.Instance.PlayersScore[player.PlayerNumber] += pointsEarnedOnClean;
        GameManager.Instance.SpawnPointsNotification(transform.position, pointsEarnedOnClean);
        // player.Item = ItemsEnum.Nothing;
        Destroy(gameObject);
    }
}
