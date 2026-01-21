using UnityEngine;
using System; // Bắt buộc có để dùng Action

public class PlayerHealth : MonoBehaviour
{
    // 1. Khai báo sự kiện (Event)
    // Action<int> nghĩa là sự kiện này gửi kèm một số nguyên (lượng máu hiện tại)
    public static event Action<int> OnHealthChanged;

    public int currentHealth = 100;

    void Update()
    {
        // Bấm H để tự làm đau mình
        if (Input.GetKeyDown(KeyCode.H))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player bị đánh! Máu còn: " + currentHealth);

        // 2. PHÁT SỰ KIỆN (Notification)
        // Dấu ? nghĩa là: Nếu có ai đăng ký thì mới báo, không thì thôi đỡ lỗi
        OnHealthChanged?.Invoke(currentHealth);
    }
}