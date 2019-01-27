using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnManager : MonoBehaviour {

    

    [SerializeField]
    private GameObject[] Enemies;
    

    [SerializeField]
    private SpawnPoint[] positions;

    public Bounds1D boundsTime = new Bounds1D(3f, 15f, false);
    private float apparition; 
    private float temps;

    private float timeLastSpawn;
    private float timeNextSpawn;

    private List<GameObject> spawned;

	void Start () {
        CleanDust();
        UpdateTimes();
	}

    void UpdateTimes()
    {
        timeLastSpawn = Time.time;
        timeNextSpawn = Random.Range(boundsTime.Min, boundsTime.Max);
    }

    void CleanDust()
    {
        if (spawned != null)
        {
            foreach(GameObject dust in spawned)
            {
                Destroy(dust);
            }
        }
        spawned = new List<GameObject>();
    }

    private void OnDestroy()
    {
        CleanDust();
    }

    void Update () {
        if (GameManager.Instance.GameState == GameManager.State.Game && Time.time > (timeLastSpawn + timeNextSpawn))
        {

            SpawnPoint[] availablePositions = positions.Where(p => p.available).ToArray();
            if (availablePositions.Length > 0)
            {
                UpdateTimes();

                int randomSpawn = Random.Range(0, availablePositions.Length);
                int randomEnemy = Random.Range(0, Enemies.Length);
                SpawnPoint position = availablePositions[randomSpawn];
                if (!position.available)
                {
                    Debug.LogError("Spawning on unavailable spot");
                }
                GameObject enemy = Instantiate(Enemies[randomEnemy], position.transform.position, Quaternion.identity);

                spawned.Add(enemy);
                Dust dust = enemy.GetComponent<Dust>();
                dust.spawnPoint = position;

                position.setAvailable(false);

            }
        }
	}

}