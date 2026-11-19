using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject missionPanel;
    public GameObject bookMessagePanel;
    public GameObject nextMissionPanel;
    public GameObject hudPanel;

    public void ShowNextMission()
    {
        missionPanel.SetActive(false);
        bookMessagePanel.SetActive(false);
        nextMissionPanel.SetActive(true);
    }

    
    public void StartMission2()
    {
        nextMissionPanel.SetActive(false); 

        if (hudPanel != null) 
        {
            hudPanel.SetActive(true); 
        }
    }
}