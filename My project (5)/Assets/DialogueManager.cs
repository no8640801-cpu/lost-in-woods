
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public GameObject missionPanel;
    public GameObject bookMessagePanel;
    public GameObject nextMissionPanel;

    public void ShowNextMission()
    {
        missionPanel.SetActive(false);
        bookMessagePanel.SetActive(false);
        nextMissionPanel.SetActive(true);
    }
}
