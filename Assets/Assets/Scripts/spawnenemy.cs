using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnDelay = 3f;           // Delay between spawns

    private float spawnTimer = 0f;

    void Start()
    {
        spawnTimer = spawnDelay; // Start with initial delay
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnDelay)
        {
            Vector3 spawnPos = new Vector3(7f, 13f, Random.Range(3f, -3f)); 

            GameObject newEnemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

            spawnTimer = 0f; // Reset timer for next spawn
        }
    }

}
