using UnityEngine;

public class collision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
    
        if (collision.gameObject.CompareTag("bullet") && this.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);   // Destroy the bullet
            Destroy(this.gameObject);        // Destroy the enemy
        }
    }
}