using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    [Header("UI Settings")]
    public GameObject canvasObject;      // Assign your Canvas here
    public string message = "You touched the shield!"; // Optional: for TMP update

    [Header("Collision Settings")]
    public LayerMask shieldLayer;        // Assign the Shield layer in Inspector
    public string playerTag = "Player";  // Make sure your player GameObject has this tag

    private void Start()
    {
        if (canvasObject != null)
        {
            canvasObject.SetActive(false); // Ensure the canvas is off initially
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only trigger if it's the player AND the shield layer
        if (other.CompareTag(playerTag) && ((1 << gameObject.layer) & shieldLayer) != 0)
        {
            if (canvasObject != null)
            {
                canvasObject.SetActive(true);

                // Optional: update TMP text if you want
                TMPro.TMP_Text tmp = canvasObject.GetComponentInChildren<TMPro.TMP_Text>();
                if (tmp != null)
                {
                    tmp.text = message;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Only hide canvas if it's the player leaving
        if (other.CompareTag(playerTag) && ((1 << gameObject.layer) & shieldLayer) != 0)
        {
            if (canvasObject != null)
            {
                canvasObject.SetActive(false);
            }
        }
    }
}
