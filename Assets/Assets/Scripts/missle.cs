using UnityEngine;

public class missle : MonoBehaviour
{
    public Vector3 startPosition;
    public float maxDistance = 50.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(5.0f, 0.0f, 0.0f)* Time.deltaTime;
        if (Vector3.Distance(startPosition, transform.position) > maxDistance)
    {
        Destroy(gameObject);
    }
    }
}
