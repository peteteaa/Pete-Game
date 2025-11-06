using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public GameUIController gameUI;
    public AudioClip explosionSound;

    void Start()
    {

        if (gameUI == null)
            gameUI = FindObjectOfType<GameUIController>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("bullet"))
        {
            // Play explosion sound once
            if (explosionSound != null)
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);


            if (gameUI != null)
                gameUI.AddScore(10);

            // Destroy bullet and enemy
            Destroy(collision.gameObject);
            Destroy(this.gameObject);


        }
    }
}
