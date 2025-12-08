using UnityEngine;

public class CubeInkTrigger : MonoBehaviour
{
    public TextAsset inkJSON;    // Drag your compiled Ink file here
    public float interactionDistance = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryStartDialogue();
        }
    }

    void TryStartDialogue()
    {
        if (InkDialogueManager.instance.IsPlaying()) return;

        // Distance check to player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.transform.position);

        if (dist <= interactionDistance)
        {
            InkDialogueManager.instance.StartStory(inkJSON);
        }
    }
}
