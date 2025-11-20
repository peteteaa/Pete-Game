using UnityEngine;
using UnityEngine.SceneManagement;

public class collision : MonoBehaviour
{
    public AudioClip explosionSound;
    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.clip = explosionSound;

        if (collision.gameObject.CompareTag("enemy") && gameObject.CompareTag("player"))
        {
            // Play explosion
            audioSource.Play();

            // Use singleton instead of Inspector reference
            GameUIController.Instance.TakeDamage(10);

            Destroy(collision.gameObject);
        }

        // Check score for scene switch
        if (GameUIController.Instance != null && GameUIController.Instance.score >= 200)
        {
            string currentScene = SceneManager.GetActiveScene().name;

            // Only switch if not already in boss scene
            if (currentScene != "Assignment8Scene2")
            {
                SceneManager.LoadScene("Assignment8Scene2");
            }
        }
    }
}
