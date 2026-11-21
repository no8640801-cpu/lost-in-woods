
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
            Debug.Log("تم الضغط على F داخل المنطقة! جاري تشغيل الحوار...");
            
            if (ConversationManager.Instance == null)
            {
                Debug.LogError("خطأ: كائن ConversationManager غير موجود في المشهد (Hierarchy)!");
                return;
            }

            if (!ConversationManager.Instance.IsConversationActive)
            {
                ConversationManager.Instance.StartConversation(myconversation);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // هذا السطر سيخبرنا في الـ Console بأي كائن يلمس التريجر وما هو الـ Tag الخاص به
        Debug.Log("كائن دخل المنطقة: " + other.name + " | الـ Tag الخاص به هو: " + other.tag);

        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Debug.Log("اللاعب أصبح في النطاق! اضغطي F الآن.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            Debug.Log("اللاعب خرج من النطاق.");
        }
    }
}
