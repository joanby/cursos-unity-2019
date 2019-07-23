using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class NPCDialogue : MonoBehaviour
{

    public string npcName;
    public string[] npcDialogueLines;
    public Sprite npcSprite;

    private DialogueManager dialogueManager;
    private bool playerInTheZone;


    // Start is called before the first frame update
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            playerInTheZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name.Equals("Player")){
            playerInTheZone = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInTheZone && Input.GetMouseButtonDown(1)){

            string[] finalDialogue = new string[npcDialogueLines.Length];

            int i = 0;
            foreach(string line in npcDialogueLines){
                finalDialogue[i++] = ((npcName != null) ? npcName + "\n" : "") + line;
            }

            if (npcSprite != null)
            {
                dialogueManager.ShowDialogue(finalDialogue, npcSprite);
            }
            else
            {
                dialogueManager.ShowDialogue(finalDialogue);
            }

            if(gameObject.GetComponentInParent<NPCMovement>()!=null){
                gameObject.GetComponentInParent<NPCMovement>().isTalking = true;
            }
        }
    }
}
