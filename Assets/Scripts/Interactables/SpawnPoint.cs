using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool available = true;

    public void setAvailable(bool available)
    {
        this.available = available;
    }
}
