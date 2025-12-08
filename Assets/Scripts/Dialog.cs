using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class InkDialogueManager : MonoBehaviour
{
    public static InkDialogueManager instance;

    [Header("UI")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public Button continueButton;

    private Story story;
    private bool dialoguePlaying;

    void Awake()
    {
        if (instance == null) instance = this;

        dialoguePanel.SetActive(false);
        continueButton.onClick.AddListener(OnContinue);
    }

    public void StartStory(TextAsset inkJSON)
    {
        story = new Story(inkJSON.text);
        dialoguePlaying = true;
        dialoguePanel.SetActive(true);

        ContinueStory();
    }

    void ContinueStory()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
        }
        else
        {
            EndStory();
        }
    }

    private void OnContinue()
    {
        if (dialoguePlaying)
        {
            ContinueStory();
        }
    }

    private void EndStory()
    {
        dialoguePlaying = false;
        dialoguePanel.SetActive(false);
    }

    public bool IsPlaying() => dialoguePlaying;
}
