using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            spawnTile();
        }
    }

    public void spawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}