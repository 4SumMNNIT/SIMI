using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallPrefabs;
    private int noOfWalls = 0;
    private float wallZgaps = 30f;
    private float moveSpeed = 5f;

    private GameObject[] walls;
    private Vector3 startPosition = new Vector3(0f, 6.5f, -10f);
    //For gradually increasing speed
    private float elaspedTime = 0f;

    void Start()
    {
        walls = new GameObject[noOfWalls];

        for (int i = 0; i < noOfWalls; i++)
        {
            Vector3 spawnPosition = new Vector3(0f, 6.5f, startPosition.z + i * wallZgaps);
            walls[i] = Instantiate(GetRandomWall(), spawnPosition, Quaternion.identity);
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
        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (walls[0].transform.position.z < startPosition.z - wallZgaps)
        {
            ReplaceWall();
        }
    }

    void ReplaceWall()
    {
        Destroy(walls[0]);

        for (int i = 0; i < walls.Length - 1; i++)
        {
            walls[i] = walls[i + 1];
        }

        Vector3 newPosition = new Vector3(0f, 6.5f, walls[walls.Length - 2].transform.position.z + wallZgaps);
        walls[walls.Length - 1] = Instantiate(GetRandomWall(), newPosition, Quaternion.identity);
    }

    GameObject GetRandomWall()
    {
        return wallPrefabs[Random.Range(0, wallPrefabs.Length)];
    }
}