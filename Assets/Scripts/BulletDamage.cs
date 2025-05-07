using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    [SerializeField] int damageAmount = 20; // จำนวนความเสียหายที่กระสุนทำ
    [SerializeField] string enemyTag = "Enemy"; // ตั้งชื่อแท็กของศัตรู

    // เมื่อชนกับ object อื่น
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าเป็นการชนกับ Enemy หรือไม่
        if (collision.gameObject.CompareTag(enemyTag))
        {
            // หาศัตรูและเรียกฟังก์ชัน TakeDamage
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damageAmount);
            }

            // ทำลายกระสุนหลังจากชน
            Destroy(gameObject);
        }
    }
}