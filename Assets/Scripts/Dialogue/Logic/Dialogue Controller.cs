using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace LFarm.Dialogue
{
    
    public class DialogueController : MonoBehaviour
    {
        public List<DialoguePiece>dialogueList = new List<DialoguePiece>();
        public UnityEvent OnFinishEvent;
        private Stack<DialoguePiece>dialogueStack;
        private bool canTalk;

        private void Awake()
        {
            FillDialogueStack();
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("player"))
            {
               
            }
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            
        }
        private void FillDialogueStack()
        {
            dialogueStack = new Stack<DialoguePiece>();
            for (int i = dialogueList.Count-1; i >-1; i--)
            {
                dialogueList[i].isDone = false;
                dialogueStack.Push(dialogueList[i]);
            }
        }
    }
}

