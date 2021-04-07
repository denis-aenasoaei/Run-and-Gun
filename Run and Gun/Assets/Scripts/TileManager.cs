using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 30;
    public int displayedTiles = 8;
    public Transform playerTransform;
    private List<GameObject> activeTiles = new List<GameObject>();
    void Start()
    {
        SpawnTile(0); // empty road
        for(int i=1; i<displayedTiles; i++)
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        float safeSpace = 35;
        if(playerTransform.position.z - safeSpace >zSpawn - (displayedTiles * tileLength) )
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int idx)
    {
        //int idx = Random.Range(1, tilePrefabs.Length - 1);
        GameObject go = Instantiate(tilePrefabs[idx], transform.forward * zSpawn, transform.rotation);
        activeTiles.Add(go);
        zSpawn += tileLength;
    }

    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
