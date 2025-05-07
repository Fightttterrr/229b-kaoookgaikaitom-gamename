using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int currentHealth;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject gameOverPanel;

    public static bool isDead = false; // ใช้ static เพื่อให้ script อื่นเข้าถึงได้ง่าย

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthText();
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthText();

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthText()
    {
        healthText.text = currentHealth + " / " + maxHealth;
    }

    void Die()
    {
        Debug.Log("Player Dead");
        isDead = true;
        gameOverPanel.SetActive(true);
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}