using UnityEngine;

public class shootenemy : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform hardpoint;
    public Transform hardpoint1;
    public AudioClip primarySound;
    public AudioSource audioSource;
    public float fireInterval = 0.5f;

    private float nextPrimaryTime_;



    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
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
}
