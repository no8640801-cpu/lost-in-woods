
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryIntroManager : MonoBehaviour
{
    [System.Serializable]
    public class StorySlide
    {
        public Sprite image;
        public AudioClip audio;
    }

    [Header("UI References")]
    public Image backgroundImage;

    [Header("Audio Settings")]
    public AudioSource audioSource;

    [Header("Story Slides")]
    public StorySlide[] slides;

    [Header("Scene Settings")]
    public string gameplaySceneName = "Gameplay";

    private void Start()
    {
        StartCoroutine(PlayStory());
    }

    private IEnumerator PlayStory()
    {
        if (slides == null || slides.Length == 0)
        {
            Debug.LogError("No story slides assigned!");
            yield break;
        }

        foreach (StorySlide slide in slides)
        {
            if (slide.image != null)
                backgroundImage.sprite = slide.image;

            audioSource.clip = slide.audio;
            audioSource.Play();

            yield return new WaitWhile(
                () => audioSource.isPlaying
            );
        }

        SceneManager.LoadScene(gameplaySceneName);
    }
}
