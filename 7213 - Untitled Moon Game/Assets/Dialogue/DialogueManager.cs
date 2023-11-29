using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    [SerializeField] TMP_Text nameText;
    [SerializeField] TMP_Text dialogueBoxText;
    [SerializeField] Image actorPortrait;

    [SerializeField] GameObject dialogueBoxGameObject;

    private Dialogue currentDialogue;
    private int dialogueTextBlockIndex = 0;

    public static DialogueManager Singleton;

    private void Awake()
    {
        if(Singleton == null)
        {
            Singleton = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void StartDialogue(Dialogue dialogue)
    {
        dialogueTextBlockIndex = 0;
        nameText.text = dialogue.actorName;
        dialogueBoxText.text = dialogue.textBlocks[dialogueTextBlockIndex];

        StartCoroutine(DisplayTextOverTimer(dialogue.textBlocks[dialogueTextBlockIndex]));

        actorPortrait.sprite = dialogue.actorPortrait;

        dialogueTextBlockIndex++;

        currentDialogue = dialogue;
       

        dialogueBoxGameObject.SetActive(true);
    }

    public void NextTextBlock()
    {
        if(dialogueTextBlockIndex >= currentDialogue.textBlocks.Length)
        {
            dialogueBoxGameObject.SetActive(false);
            return;
        }

        StartCoroutine(DisplayTextOverTimer(currentDialogue.textBlocks[dialogueTextBlockIndex]));
        dialogueTextBlockIndex++;
    }

    IEnumerator DisplayTextOverTimer(string textBlock)
    {
        dialogueBoxText.text = "";

        foreach(char character in textBlock)
        {
            dialogueBoxText.text += character;
            yield return new WaitForSeconds(0.1f);
        }
    }
    
}
