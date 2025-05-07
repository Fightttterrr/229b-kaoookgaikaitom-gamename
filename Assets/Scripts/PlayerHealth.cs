using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    int currentHealth;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] GameObject gameOverPanel;

    public static bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
        isDead = false;
        UpdateHealthText();
        Time.timeScale = 1f; // เผื่อ Restart มาแล้วหยุดเวลาไว้ก่อนหน้า
    }

    void Update()
    {
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
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

        // หยุดเวลาในเกม
        Time.timeScale = 0f;

        // หยุดนาฬิกา (GameTimer)
        GameTimer timer = FindObjectOfType<GameTimer>();
        if (timer != null)
        {
            timer.StopTimer();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}