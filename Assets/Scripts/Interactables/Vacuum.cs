using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacuum : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSelect(Interactable.Interaction interaction)
    {
        if (interaction.player.Item == ItemsEnum.Nothing)
        {
            interaction.player.Item = ItemsEnum.Vacuum;
            Destroy(gameObject);
        }
    }
}
