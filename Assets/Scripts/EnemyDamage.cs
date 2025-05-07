using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damageAmount = 50;
    [SerializeField] string playerTag = "Player";

    // เมื่อชนกับ object อื่นใน 2D
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าเป็นการชนกับผู้เล่นหรือไม่
        if (collision.gameObject.CompareTag(playerTag))
        {
            // หาผู้เล่นและเรียกฟังก์ชัน TakeDamage
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }
        }
    }
}