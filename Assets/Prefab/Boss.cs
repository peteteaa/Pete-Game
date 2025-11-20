using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed = 3f;
public float minZ = 0f;
public float maxZ = -7f;
private int direction = 1;
    public int maxHealth = 500;
    private int currentHealth;

    public AudioClip hitSound;
    public AudioSource audioSource;
    public float fireInterval = 0.5f;
    private float nextPrimaryTime_;
    public GameObject BulletPrefab;
    public Transform hardpoint;
    public Transform hardpoint1;
    public AudioClip primarySound;

    void Start()
    {
        currentHealth = maxHealth;
        nextPrimaryTime_ = Time.time + fireInterval;
    }
    void Update()
    {   
        Vector3 newPos = transform.position;
        
        newPos.z = Mathf.Clamp(newPos.z, minZ, maxZ);
        newPos.z += speed * direction * Time.deltaTime;

        if (newPos.z >= maxZ) direction = -1; // switch down
        if (newPos.z <= minZ) direction = 1;  // switch up
        transform.position = newPos;

        if (Time.time > nextPrimaryTime_)
        {
            Instantiate(BulletPrefab, hardpoint.transform.position, hardpoint.rotation);
            Instantiate(BulletPrefab, hardpoint1.transform.position, hardpoint1.rotation);
            if (audioSource != null && primarySound != null)
            {
                audioSource.clip = primarySound;
                audioSource.Play();
            }
            nextPrimaryTime_ = Time.time + fireInterval;
        }
    }

    void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("bullet"))
    {
        TakeDamage(10); // or whatever amount
        Destroy(other.gameObject);
    }
}
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;

        if (audioSource != null && hitSound != null)
            audioSource.PlayOneShot(hitSound);

        Debug.Log("Boss Health: " + currentHealth);

        if (currentHealth <= 0)
        {
            GameUIController.Instance.AddScore(1000);
            Destroy(gameObject);
        }
    }

}
