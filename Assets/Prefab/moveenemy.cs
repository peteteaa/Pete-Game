using UnityEngine;

public class moveenemy : MonoBehaviour
{
public float speed = 5f;
private Vector3 spawnpos;

    void Start()
    {
        spawnpos = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(spawnpos, transform.position) >= 50f)
        {
            Destroy(gameObject);

        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
   
}
