using UnityEngine;

public class collision : MonoBehaviour
{
    public AudioClip explosionSound;
    public AudioSource audioSource;
    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = explosionSound;

        if (collision.gameObject.CompareTag("bullet") && this.gameObject.CompareTag("enemy"))
        {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            Destroy(collision.gameObject);   // Destroy the bullet
            Destroy(this.gameObject);        // Destroy the enemy        


        }
        if (collision.gameObject.CompareTag("enemy") && this.gameObject.CompareTag("player"))
        {
            // Pause the game when player collides with enemy
            Time.timeScale = 0f;
                audioSource.Play();

        }

        
    }
}