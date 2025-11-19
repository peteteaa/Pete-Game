using UnityEngine;

public class spawnenemy : MonoBehaviour
{
    public GameObject enemyA;
    public GameObject enemyB;
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
            Vector3 spawnPos = new Vector3(7f, 13f, Random.Range(-3f, 3f));
            GameObject enemyspawned;

        if (Random.value < 0.5f)
        {
            enemyspawned = enemyA;
        }
        else
        {
            enemyspawned = enemyB;
        }            Instantiate(enemyspawned, spawnPos, Quaternion.identity);

            spawnTimer = 0f; // Reset timer for next spawn
        }
    }

}
