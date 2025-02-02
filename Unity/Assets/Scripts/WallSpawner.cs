using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public GameObject[] wallPrefabs; 
    public int noOfWalls = 15;       
    public float wallZgaps = 5f;    
    public float moveSpeed = 0f;    

    private GameObject[] walls;     
    private Vector3 startPosition = new Vector3(0f, -2f, -10f);

    void Start()
    {
        walls = new GameObject[noOfWalls];

        for (int i = 0; i < noOfWalls; i++)
        {
            Vector3 spawnPosition = new Vector3(0f, -2f, startPosition.z + i * wallZgaps);
            walls[i] = Instantiate(GetRandomWall(), spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
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

        Vector3 newPosition = new Vector3(0f, -2f, walls[walls.Length - 2].transform.position.z + wallZgaps);
        walls[walls.Length - 1] = Instantiate(GetRandomWall(), newPosition, Quaternion.identity);
    }

    GameObject GetRandomWall()
    {
        return wallPrefabs[Random.Range(0, wallPrefabs.Length)];
    }
}