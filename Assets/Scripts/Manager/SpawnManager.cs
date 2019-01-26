using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : SingletonBehaviour<SpawnManager> {

    

    [SerializeField]
    private GameObject[] Enemies;
    

    [SerializeField]
    private Transform[] positions;

    public float minimum;
    public float maximum;
    private float apparition; 
    private float temps;
    private int RandomSpawn;
    private int RandomEnemy;


	void Start () {
        Spawn();
	}
	
	
	void Update () {
        
	}

    void Spawn()
    {
        float randomTime = Random.Range(minimum, maximum);
        Invoke("Spawn", randomTime);
        RandomSpawn = Random.Range(0, positions.Length);
        RandomEnemy = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[RandomEnemy], positions[RandomSpawn].position, positions[RandomSpawn].rotation); 
    }
}