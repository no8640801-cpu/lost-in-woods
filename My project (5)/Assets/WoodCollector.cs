
using UnityEngine;
using TMPro;

public class WoodCollector : MonoBehaviour
{
    [Header("Wood Settings")]
    public int collectedWood = 0;
    public int requiredWood = 5;

    [Header("UI")]
    public TMP_Text woodCounterText;
    public TMP_Text timerText;

    [Header("Timer")]
    public float timeLeft = 60f;

    [Header("Game Over")]
    public GameOverManager gameOverManager;

    private bool missionActive = true;

    void Start()
    {
        UpdateCounter();
        UpdateTimer();
    }

    void Update()
    {
        if (!missionActive)
            return;

        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
        {
            timeLeft = 0;
            missionActive = false;

            UpdateTimer();

            Debug.Log("Time is up! Mission Failed!");

            if (gameOverManager != null)
                gameOverManager.GameOver();
            else
                Debug.LogError("GameOverManager is not assigned!");

            return;
        }

        UpdateTimer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!missionActive)
            return;

        if (other.CompareTag("suitable"))
        {
            collectedWood++;

            Destroy(other.gameObject);

            UpdateCounter();

            if (collectedWood >= requiredWood)
            {
                missionActive = false;

                Debug.Log("Mission Completed!");
            }
        }
        else if (other.CompareTag("unsuitable"))
        {
            Debug.Log("This wood is not suitable!");
        }
    }

    void UpdateCounter()
    {
        if (woodCounterText != null)
        {
            woodCounterText.text =
                "Wood: " + collectedWood + "/" + requiredWood;
        }
    }

    void UpdateTimer()
    {
        if (timerText != null)
        {
            timerText.text =
                "Time: " + Mathf.Ceil(timeLeft);
        }
    }
}
