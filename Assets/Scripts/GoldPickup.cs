using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int goldAmount = 1;

    private void OnTriggerEnter(Collider other)
    {
        // --- STEP 1: Check if the collision is even registering ---
        // This will ALWAYS print if the trigger is firing, regardless of the tag.
        Debug.Log("Trigger Registered! Colliding Object: " + other.gameObject.name);

        // Check if the colliding object's tag is exactly "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Confirmed. Adding Gold.");
            
            // Check if the manager exists before trying to use it
            if (GoldManager.instance != null)
            {
                GoldManager.instance.AddGold(goldAmount);
                Destroy(gameObject);
            }
            else
            {
                // FATAL ERROR if the manager is missing
                Debug.LogError("FATAL ERROR: GoldManager.instance is NULL! Is the GoldManager script attached to a GameObject in your scene?");
            }
        }
    }
}