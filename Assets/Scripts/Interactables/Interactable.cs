using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class InteractableEvent : UnityEvent<Interactable.Interaction> {

}

public class Interactable : MonoBehaviour
{
    public struct Interaction
    {
        public Player player;
    }

    [SerializeField]
    InteractableEvent onInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteraction(Interaction interaction)
    {
        onInteraction.Invoke(interaction);
    }
}
