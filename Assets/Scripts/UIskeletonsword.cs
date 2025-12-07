using UnityEngine;
using System.Collections;
using TMPro; // Needed for TextMeshProUGUI

public class IntroMessageController : MonoBehaviour
{
    // Drag your Canvas Group component here in the Inspector (REQUIRED for fading)
    public CanvasGroup messageCanvasGroup; 

    // Reference to the Text component to set the message
    public TextMeshProUGUI messageText; 

    [Header("Timing (Seconds)")]
    public float fadeInDuration = 0.5f;   // Time to fade from 0% to 100% alpha
    public float displayDuration = 2.0f;  // Time to stay fully opaque
    public float fadeOutDuration = 0.5f;  // Time to fade from 100% to 0% alpha
    
    // The message content
    private const string MESSAGE = 
        "HUNT DOWN the skeleton sword at the end of the maze to win! Fight through enemies and claim their treasure!";

    void Start()
    {
        // 1. Set the text content
        if (messageText != null)
        {
            messageText.text = MESSAGE;
        }

        // 2. Ensure the panel starts active but invisible (alpha 0)
        if (messageCanvasGroup != null)
        {
            messageCanvasGroup.gameObject.SetActive(true);
            messageCanvasGroup.alpha = 0f;
        }

        // 3. Start the entire sequence
        StartCoroutine(SequenceMessageDisplay());
    }

    private IEnumerator SequenceMessageDisplay()
    {
        // --- 1. Fade In ---
        yield return FadeCanvas(1f, fadeInDuration); // Fade to full opacity (1)

        // --- 2. Wait ---
        yield return new WaitForSeconds(displayDuration); // Pause fully visible

        // --- 3. Fade Out ---
        yield return FadeCanvas(0f, fadeOutDuration); // Fade to fully transparent (0)

        // --- 4. Disable Object ---
        if (messageCanvasGroup != null)
        {
            messageCanvasGroup.gameObject.SetActive(false);
        }
    }

    // Coroutine to handle the actual fading process smoothly
    private IEnumerator FadeCanvas(float targetAlpha, float duration)
    {
        if (messageCanvasGroup == null) yield break;

        float startAlpha = messageCanvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            // Use Lerp to smoothly transition the alpha value over time
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, time / duration);
            messageCanvasGroup.alpha = newAlpha;
            yield return null; // Wait until next frame
        }
        
        // Ensure we end exactly at the target value (0 or 1)
        messageCanvasGroup.alpha = targetAlpha;
    }
}