using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Life : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthSlider;
    public float fallAngleX = 90f;
    public bool isDead;

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
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
        if (isDead) return;

        if (hitObject.CompareTag("ew"))
        {
            currentHealth = Mathf.Clamp(currentHealth - 50f, 0f, maxHealth);
            UpdateHealthUI();
            Destroy(hitObject);
            CheckDeath();
        }
        else if (hitObject.CompareTag("yum"))
        {
            currentHealth = Mathf.Clamp(currentHealth + 20f, 0f, maxHealth);
            UpdateHealthUI();
            Destroy(hitObject);
        }
        void UpdateHealthUI()
    {
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }
    }

        void CheckDeath()
        {
            if (currentHealth <= 0f && !isDead)
            {
                isDead = true;
                transform.Rotate(fallAngleX, 0f, 0f, Space.Self);
                Debug.Log("Game Over!");
            }
        }
    }
}