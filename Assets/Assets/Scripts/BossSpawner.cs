using UnityEngine;


public class BossSpawner : MonoBehaviour
{
    public GameObject bossPrefab;
    public Transform spawnPoint;
    public static bool bossSpawned = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
        void Update()
        {
            // Check if the boss has already spawned
            if (!bossSpawned && GameUIController.Instance != null && GameUIController.Instance.score % 400 ==0 )
            {
                Instantiate(bossPrefab, spawnPoint.position, spawnPoint.rotation);
                bossSpawned = true; // Ensure it only spawns once

            }
        }

}
