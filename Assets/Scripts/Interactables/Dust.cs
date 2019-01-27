using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    [SerializeField]
    private int pointsEarnedOnClean;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract(Interactable.Interaction interaction)
    {
        if (interaction.player.Item == ItemsEnum.Vacuum)
        {
            GameManager.Instance.PlayersScore[interaction.player.PlayerNumber] += pointsEarnedOnClean;
            interaction.player.Item = ItemsEnum.Nothing;
            Destroy(gameObject);
        }
    }
}
