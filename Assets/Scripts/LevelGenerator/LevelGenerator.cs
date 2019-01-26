using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : SingletonBehaviour<LevelGenerator>
{
    [SerializeField]
    private Vector2Int size;
    [SerializeField]
    private GameObject[] tilePrefabs;
    [SerializeField]
    private GameObject startTilePrefab;

    private List<GameObject> tilesMap;

    private GameObject GetRandomTilePrefab()
    {
        return tilePrefabs[Random.Range(0, tilePrefabs.Length)];
    }

    public void CleanMap()
    {
        if (tilesMap != null)
        {
            foreach(GameObject tile in tilesMap)
            {
                Destroy(tile);
            }
        }
    }

    public void GenerateMap()
    {
        CleanMap();
        Bounds tileBounds = startTilePrefab.GetComponentInChildren<Renderer>().bounds;
        Vector3 offset = new Vector3(tileBounds.size.x * (size.x - 1), 0f, tileBounds.size.z * (size.y - 1)) * -0.5f;

        int startPosition = Random.Range(0, size.x * size.y);
        tilesMap = new List<GameObject>(size.x * size.y);
        for (int j = 0; j < size.y; ++j)
        {
            for (int i = 0; i < size.x; ++i)
            {
                GameObject prefab = ((j * size.x) + i == startPosition) ? startTilePrefab : GetRandomTilePrefab();
                Vector3 position = new Vector3(i * tileBounds.size.x, 0f, j * tileBounds.size.z) + offset;
                GameObject newTile = Instantiate(prefab, position, Quaternion.identity, transform);
                tilesMap.Add(newTile);
            }
        }
    }
}
