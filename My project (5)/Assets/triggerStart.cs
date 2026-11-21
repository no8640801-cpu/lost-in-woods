
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class triggerStart : MonoBehaviour
{
    [SerializeField] private NPCConversation myconversation;
    private bool isPlayerInRange = false;

    private void Update()
    {
       
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
           
            if (!ConversationManager.Instance.IsConversationActive)
            {
                ConversationManager.Instance.StartConversation(myconversation);
            }
        }
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }
}
