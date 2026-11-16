using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour


{
    public static GameManager Instance;

    [Header("Score")]
    public int mushroomCount = 0;
    public int targetCount = 5;
    public TMP_Text scoreText;

    [Header("Timer")]
    public float timeLimit = 60f;
    private float timeRemaining;
    public TMP_Text timerText;

    public TMP_Text messageText;

    private bool gameEnded = false;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        timeRemaining = timeLimit;
        UpdateUI();
        messageText.text = "";
    }

    void Update()
    {
        if (gameEnded)
            return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            EndGame(false);
        }

        UpdateUI();
    }

    public void CollectMushroom(bool isPoisonous)
    {
        if (gameEnded)
            return;

        if (isPoisonous)
        {
            mushroomCount = Mathf.Max(0, mushroomCount - 1);
        }
        else
        {
            mushroomCount++;
        }

        UpdateUI();

        if (mushroomCount >= targetCount)
        {
            EndGame(true);
        }
    }

    void UpdateUI()
    {
        scoreText.text = "Mushrooms: " +
                         mushroomCount + "/" + targetCount;

        timerText.text = "Time: " +
                         Mathf.CeilToInt(timeRemaining);
    }

    void EndGame(bool won)
    {
        gameEnded = true;

        if (won)
            messageText.text = "You Win!";
        else
            messageText.text = "Time's Up! Try Again!";
    }
}

