
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float fallAngleX = 90f;
    public bool isDead;

    [Header("UI")]
    public Slider healthSlider;
    public TMP_Text healthText;

    [Header("References")]
    public MonoBehaviour movement;
    public GameOverManager gameOverManager;

    private Rigidbody rb;
    private Animator anim;

    void Start()
    {
        currentHealth = 30;
        isDead = false;

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }

        UpdateHealthUI();
    }

    private void OnCollisionEnter(Collision collision)
    {
        HandleMushroomHit(collision.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        HandleMushroomHit(other.gameObject);
    }

    void HandleMushroomHit(GameObject hitObject)
    {
        if (isDead)
            return;

        if (hitObject.CompareTag("ew"))
        {
            currentHealth = Mathf.Clamp(
                currentHealth - 50f, 0f, maxHealth
            );

            Destroy(hitObject);

            UpdateHealthUI();
            CheckDeath();
        }
        else if (hitObject.CompareTag("yum"))
        {
            currentHealth = Mathf.Clamp(
                currentHealth + 20f, 0f, maxHealth
            );

            Destroy(hitObject);

            UpdateHealthUI();
        }
    }

    void UpdateHealthUI()
    {
        if (healthSlider != null)
            healthSlider.value = currentHealth;

        if (healthText != null)
            healthText.text = currentHealth.ToString("0");
    }

    void CheckDeath()
    {
        if (currentHealth <= 0f && !isDead)
        {
            isDead = true;

            UpdateHealthUI();

            if (movement != null)
                movement.enabled = false;

            if (anim != null)
                anim.enabled = false;

            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                rb.isKinematic = true;
            }

            if (gameOverManager != null)
                gameOverManager.GameOver();
            else
                Debug.LogError("GameOverManager is not assigned!");
        }
    }
}
