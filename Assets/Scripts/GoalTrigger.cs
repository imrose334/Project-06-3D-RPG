using UnityEngine;
using UnityEngine.SceneManagement;

public class GoalTrigger : MonoBehaviour
{
    // *** IMPORTANT: Set this to the exact name of your End Menu scene ***
    public string endSceneName = "EndMenu";

    private void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has the "Player" tag
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player reached the goal! Loading End Menu.");

            // Load the End Menu scene. 
            // The MenuManager script will ensure the game is unpaused upon entering the new scene.
            SceneManager.LoadScene(endSceneName);
        }
    }
}