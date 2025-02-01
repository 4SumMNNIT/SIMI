using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    public GameObject groundTilePrefab;  
    public int numberOfTiles = 15;       
    public float tileLength = 5f;       
    public float moveSpeed = 5f;       

    private GameObject[] groundTiles;   
    private Vector3 startPosition = new Vector3(0f, -4f, -10f); 

    void Start()
    {
        groundTiles = new GameObject[numberOfTiles];

        for (int i = 0; i < numberOfTiles; i++)
        {
            Vector3 spawnPosition = startPosition + new Vector3(0f, 0f, i * tileLength);
            groundTiles[i] = Instantiate(groundTilePrefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        for (int i = 0; i < groundTiles.Length; i++)
        {
            groundTiles[i].transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }

        if (groundTiles[0].transform.position.z < startPosition.z - tileLength)
        {
            RepositionTile();
        }
    }

    void RepositionTile()
    {
        GameObject tileToMove = groundTiles[0];

        Vector3 newPosition = groundTiles[groundTiles.Length - 1].transform.position + new Vector3(0f, 0f, tileLength);
        tileToMove.transform.position = newPosition;

        for (int i = 0; i < groundTiles.Length - 1; i++)
        {
            groundTiles[i] = groundTiles[i + 1];
        }
        groundTiles[groundTiles.Length - 1] = tileToMove;
    }
}
