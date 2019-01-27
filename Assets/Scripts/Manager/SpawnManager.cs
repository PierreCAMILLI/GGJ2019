using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

    

    [SerializeField]
    private GameObject[] Enemies;
    

    [SerializeField]
    private Transform[] positions;

    public Bounds1D boundsTime;
    private float apparition; 
    private float temps;

    private float timeLastSpawn;
    private float timeNextSpawn;

	void Start () {
        UpdateTimes();
	}
	
	void UpdateTimes()
    {
        timeLastSpawn = Time.time;
        timeNextSpawn = Random.Range(boundsTime.Min, boundsTime.Max);
    }

	void Update () {
        if (GameManager.Instance.GameState == GameManager.State.Game && Time.time > (timeLastSpawn + timeNextSpawn))
        {
            UpdateTimes();

            int randomSpawn = Random.Range(0, positions.Length);
            int randomEnemy = Random.Range(0, Enemies.Length);
            Instantiate(Enemies[randomEnemy], positions[randomSpawn].position, positions[randomSpawn].rotation);
        }
	}

}