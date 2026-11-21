using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class triggerStart : MonoBehaviour
{
   
      [SerializeField]  private NPCConversation myconversation ;
    
private void onTriggerStay(Collider other)
  {
      if (other.CompareTag("Player"))
      {
           if (Input.GetKeyDown(KeyCode.F))
           {
               ConversationManager.Instance.StartConversation(myconversation);
           }
      }
  }
     
}
