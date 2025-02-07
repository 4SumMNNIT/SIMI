using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    private int numberOfTiles = 10;
    private float tileLength = 50f;
    private float moveSpeed = 5f;
    public GameObject[] Levels;
    private int prevIndx = -1;
    private GameObject[] groundTiles;
    private Vector3 startPosition = new Vector3(0f, -1.5f, -10f);
    private float elapsedTime = 0f;

    void Start()
    {
        groundTiles = new GameObject[numberOfTiles];

        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(0f, 0f, i * tileLength);
            int idx = GetUniqueRandomIndex();
            groundTiles[i] = Instantiate(Levels[idx], spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= 10f)
        {
            moveSpeed += 1;
            elapsedTime = 0f;
        }

        foreach (GameObject tile in groundTiles)
        {
            tile.transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (groundTiles[0].transform.position.z < startPosition.z - tileLength)
        {
            SpawnNewWall();
        }
    }

    void SpawnNewWall()
    {
        Destroy(groundTiles[0]);
        for (int i = 0; i < groundTiles.Length - 1; i++)
        {
            groundTiles[i] = groundTiles[i + 1];
        }

        int idx = GetUniqueRandomIndex();
        Vector3 newPosition = groundTiles[^2].transform.position + new Vector3(0f, 0f, tileLength);
        groundTiles[^1] = Instantiate(Levels[idx], newPosition, Quaternion.identity);
    }

    int GetUniqueRandomIndex()
    {
        int idx;
        if (Levels.Length > 1)
        {
            do
            {
                idx = Random.Range(0, Levels.Length);
            } while (idx == prevIndx);
        }
        else
        {
            idx = 0;
        }
        prevIndx = idx;
        return idx;
    }
}