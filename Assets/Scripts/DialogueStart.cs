using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DialogueStart : MonoBehaviour
{
    public GameObject conversation;
    private GameObject dialogueManager;

    public string nextScene;

    private bool proceed;
    private bool spaceAllow;

	void Start ()
    {
        dialogueManager = GameObject.Find("DialogueManager");
        StartCoroutine(Waiting());
    }

    void Update()
    {
        proceed = dialogueManager.GetComponent<DialogueManager>().conversationEnd;

        if (Input.GetKeyDown("space") && spaceAllow)
        {
            dialogueManager.GetComponent<DialogueManager>().DisplayNextSentence();
        }

        if (proceed)
        {
            StartCoroutine(Waiting());
        }
    }

    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(2);
        if (proceed)
        {
            SceneManager.LoadScene(nextScene);
        }
        else
        {
            spaceAllow = true;
            conversation.GetComponent<DialogueTrigger>().TriggerDialogue();
        }
    }
}
