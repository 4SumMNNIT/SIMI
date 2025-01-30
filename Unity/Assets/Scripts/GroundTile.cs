using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    public float speed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnTile();
        Destroy(gameObject, 2);
    }

    // public void FixedUpdate()
    // {
    //     //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
    //     //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * 2;




    // }

    // Update is called once per frame
    void Update()
    {

    }
}
