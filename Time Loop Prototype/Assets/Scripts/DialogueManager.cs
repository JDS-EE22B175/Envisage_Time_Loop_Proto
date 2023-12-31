using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    [SerializeField] GameObject player;
    public float textSpeed = 0.05f; // Adjust the speed as needed
    
    private List<string> dialogueLines;

    private bool isDisplayingText;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return)) && isDisplayingText)
        {
            // If the player clicks while text is being displayed, show the entire text
            dialogueText.text = dialogueLines[0]; // Display the entire current line
            StopCoroutine("ShowDialogueText");
            isDisplayingText = false;
        }
    }

    public IEnumerator ShowDialogueText(List<string> dialoguelines)
    {
        dialogueLines = dialoguelines;
        isDisplayingText = true;

        foreach (string line in dialoguelines)
        {
            dialogueText.text = "";
            for (int i = 0; i < line.Length; i++)
            {
                dialogueText.text += line[i];
                yield return new WaitForSeconds(textSpeed);
            }

            // Wait for player input or a fixed delay before moving to the next line
            float delay = Input.GetMouseButtonDown(0) ? 0.0f : 2.0f; // Change delay time as needed
            yield return new WaitForSeconds(delay);
        }

        isDisplayingText = false;
        dialogueText.text = "";
        gameObject.SetActive(false);
        player.GetComponent<PlayerInteract>().isinteracting = false;
    }
}
