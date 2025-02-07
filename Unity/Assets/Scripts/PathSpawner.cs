using UnityEngine;
using UnityEngine.UIElements;

public class PathSpawner : MonoBehaviour
{
    //Common variables
    private float wallZgaps = 35f;
    private float moveSpeed = 5f; 
    private float elaspedTime = 0f;
    public int prevIndx = 0;


    //Array to store different types of walls
    public GameObject[] wallPrefabs;
    private int noOfWalls = 7;
    


    //Array to store current walls
    private GameObject[] walls;
    public Vector3 startPositionWall = new Vector3(0f, 4f, -10f);
    

  
    
    //Array for different ground
    public GameObject[] Levels;
    private int numberOfTiles = 5;
    private float tileLength = 50f;
    
    //Array to store current ground
    private GameObject[] groundTiles;    // Array to store the Ground tiles
    public Vector3 startPosition = new Vector3(0f, -1.5f, -10f); 
    void Start()
    {



        //For walls===============
        walls = new GameObject[noOfWalls];

        for (int i = 0; i < noOfWalls; i++)
        {
            Vector3 spawnPosition = new Vector3(0f, 4f, startPositionWall.z + i * wallZgaps);
            walls[i] = Instantiate(GetRandomWall(), spawnPosition, Quaternion.identity);
        }
        //For walls===============





        //For Grround===============
        groundTiles = new GameObject[numberOfTiles];
        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(0f, 0f, i * tileLength);
            int idx = Random.Range(0, Levels.Length);  // Randomly pick a wall prefab
            prevIndx = idx;
            while (prevIndx == idx)
            {
                idx = Random.Range(0, Levels.Length);
            }
            GameObject floor = Levels[idx];
            groundTiles[i] = Instantiate(floor, spawnPosition, Quaternion.identity);
        }

        //For Grround===============


    }


    void Update()
    {
        elaspedTime += Time.deltaTime;

        int time = Mathf.RoundToInt(elaspedTime);

        if (time == 10)
        {
            moveSpeed += 1;
            elaspedTime = 0;

        }
        //For Wall=======================
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (walls[0].transform.position.z < startPositionWall.z - wallZgaps)
        {
            ReplaceWall();
        }
        //For Wall=======================






        //For Ground=========================
        for (int i = 0; i < groundTiles.Length; i++)
        {
            groundTiles[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        // Check if the first tile has moved past the reset threshold
        if (groundTiles[0].transform.position.z < startPosition.z - tileLength)
        {
            SpawnNewGround();  
        }
        //For Ground=========================



    }


    //for generating new tile
    void SpawnNewGround()
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






    //wall destroy and random generator
    void ReplaceWall()
    {
        Destroy(walls[0]);

        for (int i = 0; i < walls.Length - 1; i++)
        {
            walls[i] = walls[i + 1];
        }

        Vector3 newPosition = new Vector3(0f, 4f, walls[walls.Length - 2].transform.position.z + wallZgaps);
        walls[walls.Length - 1] = Instantiate(GetRandomWall(), newPosition, Quaternion.identity);
    }

    GameObject GetRandomWall()
    {
        return wallPrefabs[Random.Range(0, wallPrefabs.Length)];
    }
}
