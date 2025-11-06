using UnityEngine;

public class collision : MonoBehaviour
{
    public AudioClip explosionSound;
    public AudioSource audioSource;
    public GameUIController gameUI;
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = explosionSound;
        if (collision.gameObject.CompareTag("enemy") && this.gameObject.CompareTag("player"))
        {
            // Pause the game when player collides with enemy

                audioSource.Play();
                 gameUI.TakeDamage(100);
                 Destroy(collision.gameObject);

        }

        
    }
}