using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // FIX: Static instance allows MenuManager to access this script
    public static DayNightCycle instance;

    // The total time for one full day/night cycle (in seconds).
    public float cycleDurationSeconds = 120.0f; 

    private float rotationSpeed;
    // FIX: Store the initial rotation so we can reset to it
    private Quaternion initialRotation; 

    void Awake()
    {
        // Set the static instance when the script starts
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        rotationSpeed = 360f / cycleDurationSeconds;
        
        // FIX: Store the current rotation as the starting point (e.g., X=90 for midday)
        initialRotation = transform.rotation;
    }

    void Update()
    {
        // Rotate the Directional Light only if the game is not paused (Time.timeScale > 0).
        if (Time.timeScale > 0)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            transform.Rotate(rotationAmount, 0, 0, Space.World);
        }
    }
    
    // FIX: NEW FUNCTION to be called by MenuManager to reset the skybox/light
    public void ResetLightingForMainMenu()
    {
        // Force the light rotation back to the initial starting angle
        transform.rotation = initialRotation;
    }
}