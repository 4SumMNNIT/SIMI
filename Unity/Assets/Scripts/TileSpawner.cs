using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;  // The ground tile prefab
    private int numberOfTiles = 5;       // Number of tiles to spawn initially
    private float tileLength = 50f;        // Length of each tile
    private float moveSpeed = 1f;         // Speed at which tiles will move
    public GameObject[] Levels;          // Array of wall prefabs

    public int prevIndx = 0;
    public GameObject[] groundTiles;    // Array to store the tiles
    public Vector3 startPosition = new Vector3(0f, -1.5f, -10f); // Updated start position

    //For gradually increasing speed
    private float elaspedTime = 0f;

    void Start()
    {
        groundTiles = new GameObject[numberOfTiles];

        // Spawn the initial tiles in a row
        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(0f, 0f, i * tileLength);
            int idx = Random.Range(0, Levels.Length);  // Randomly pick a wall prefab
            prevIndx = idx;
            while(prevIndx == idx)
            {
                idx = Random.Range(0, Levels.Length);
            }
            GameObject floor = Levels[idx];
            groundTiles[i] = Instantiate(floor, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {


        //Trying to gradually increase the speed 
        elaspedTime += Time.deltaTime;

        int time = Mathf.RoundToInt(elaspedTime);

        if (time == 10)
        {
            moveSpeed += 1;
            elaspedTime = 0;

        }

        // Move all the tiles backward over time
        for (int i = 0; i < groundTiles.Length; i++)
        {
            groundTiles[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Check if the first tile has moved past the reset threshold
        if (groundTiles[0].transform.position.z < startPosition.z - tileLength)
        {
            SpawnNewWall();  // Spawn a new wall at the front
        }
    }

    void SpawnNewWall()
    {
        // Destroy the tile at the back (first tile in the array)
        Destroy(groundTiles[0]);

        // Move the remaining tiles in the array forward by one spot
        for (int i = 0; i < groundTiles.Length - 1; i++)
        {
            groundTiles[i] = groundTiles[i + 1];
        }

        // Randomly choose a new wall prefab
        int idx = Random.Range(0, Levels.Length);
        while (prevIndx == idx)
        {
            idx = Random.Range(0, Levels.Length);
        }

        prevIndx = idx;
        GameObject newWall = Levels[idx];

        // Instantiate the new wall at the front
        Vector3 newPosition = groundTiles[groundTiles.Length - 1].transform.position + new Vector3(0f, 0f, tileLength);
        groundTiles[groundTiles.Length - 1] = Instantiate(newWall, newPosition, Quaternion.identity);
    }
}