using UnityEngine;
using TMPro; // Correctly using TMPro

public class GoldManager : MonoBehaviour
{
    // Make sure this is linked to a TextMeshPro UI element in the Inspector
    public TMP_Text goldText; 
    public static GoldManager instance;
    private int gold = 0;

    void Awake()
    {
        // Ensures there is only one GoldManager instance
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        UpdateUI();
    }

    public void AddGold(int amount)
    {
        gold += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (goldText != null)
            goldText.text = "Gold: " + gold.ToString(); // Added "Gold: " for clarity
        else
            Debug.LogWarning("GoldText not assigned!");
    }
}