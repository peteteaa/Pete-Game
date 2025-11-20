using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StartGame : MonoBehaviour
{


    void Update()
    {
        if (Input.anyKeyDown)
        {
                    Debug.Log("Any key pressed!");

            // Load your first game scene
            SceneManager.LoadScene("Assignment8Scene1"); 
        }
    }
}


