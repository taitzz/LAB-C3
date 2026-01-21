using UnityEngine;
using UnityEngine.UI; // Để dùng UI Text

public class GameObservers : MonoBehaviour
{
    public Text healthText; // Kéo UI Text vào đây

    // 1. Đăng ký kênh khi bật Object
    private void OnEnable()
    {
        // Cú pháp: Tên_Class.Tên_Sự_Kiện += Hàm_Xử_Lý
        PlayerHealth.OnHealthChanged += UpdateUI;
        PlayerHealth.OnHealthChanged += PlaySound;
        PlayerHealth.OnHealthChanged += CheckGameOver;
    }

    // 2. Hủy đăng ký khi tắt/xóa Object (RẤT QUAN TRỌNG để tránh lỗi)
    private void OnDisable()
    {
        // Cú pháp: Dùng dấu -=
        PlayerHealth.OnHealthChanged -= UpdateUI;
        PlayerHealth.OnHealthChanged -= PlaySound;
        PlayerHealth.OnHealthChanged -= CheckGameOver;
    }

    // --- CÁC HÀM XỬ LÝ (Sẽ chạy khi Player báo tin) ---

    // Nhiệm vụ 1: Cập nhật UI
    void UpdateUI(int newHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + newHealth;
        }
    }

    // Nhiệm vụ 2: Giả lập âm thanh
    void PlaySound(int newHealth)
    {
        Debug.Log("🔊 Âm thanh: Á á á! (Đã phát tiếng kêu đau)");
    }

    // Nhiệm vụ 3: Kiểm tra Game Over
    void CheckGameOver(int newHealth)
    {
        if (newHealth <= 0)
        {
            Debug.Log("💀 GAME OVER! Bạn đã hy sinh.");
            // Ở đây có thể hiện màn hình thua cuộc hoặc load lại game
            if (healthText != null) healthText.text = "YOU DIED";
        }
    }
}