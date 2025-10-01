using UnityEngine;
using System.Collections.Generic;

public class LoopingPlaneManager : MonoBehaviour
{
    public GameObject planePrefab;   // Assign your plane prefab here
    public float scrollSpeed = 5f;   // Speed of movement
    private float width;             // Width of a single plane
    private List<Transform> activePlanes = new List<Transform>();

    void Start()
    {
        // Get width from prefab
        width = planePrefab.GetComponent<Renderer>().bounds.size.x;

        // Spawn initial plane(s)
        Vector3 startPos = Vector3.zero;
        GameObject firstPlane = Instantiate(planePrefab, startPos, Quaternion.identity);
        activePlanes.Add(firstPlane.transform);
    }

    void Update()
    {
        // Move all active planes
        for (int i = 0; i < activePlanes.Count; i++)
        {
            activePlanes[i].Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        }

        // Spawn new plane ahead if needed
        Transform rightMost = activePlanes[activePlanes.Count - 1];
        if (rightMost.position.x <= Camera.main.transform.position.x + width)
        {
            Vector3 newPos = new Vector3(rightMost.position.x + width, rightMost.position.y, rightMost.position.z);
            GameObject newPlane = Instantiate(planePrefab, newPos, Quaternion.identity);
            activePlanes.Add(newPlane.transform);
        }

        // Destroy plane behind if offscreen
        Transform leftMost = activePlanes[0];
        if (leftMost.position.x < Camera.main.transform.position.x - 2 * width)
        {
            activePlanes.RemoveAt(0);
            Destroy(leftMost.gameObject);
        }
    }
}
