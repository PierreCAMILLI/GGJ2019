using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private Vector2Int size;
    [SerializeField]
    private GameObject[] tilePrefabs;

    private List<GameObject> tilesMap;

    private void Start()
    {
        GenerateMap();
    }

    private GameObject GetRandomTilePrefab()
    {
        return tilePrefabs[Random.Range(0, tilePrefabs.Length - 1)];
    }

    void GenerateMap()
    {
        Bounds tileBounds = GetRandomTilePrefab().GetComponentInChildren<Renderer>().bounds;
        //Vector3 offset = new Vector3(tileBounds.size.x * size.x, 0f, tileBounds.size.z * size.y) * -0.5f + (tileBounds.size.X0Z() * 0.5f);
        Vector3 offset = new Vector3(tileBounds.size.x * (size.x - 1), 0f, tileBounds.size.z * (size.y - 1)) * -0.5f;

        tilesMap = new List<GameObject>();
        for (int j = 0; j < size.y; ++j)
        {
            for (int i = 0; i < size.x; ++i)
            {
                Vector3 position = new Vector3(i * tileBounds.size.x, 0f, j * tileBounds.size.z) + offset;
                GameObject newTile = Instantiate(GetRandomTilePrefab(), position, Quaternion.identity, transform);
                tilesMap.Add(newTile);
            }
        }
    }
}
