using UnityEngine;
using UnityEngine.UI; // Nhớ dòng này

public class GameManager : MonoBehaviour
{
    public Text hpText;      // Kéo UI HP vào
    public Text statusText;  // Kéo UI Status vào

    void OnEnable()
    {
        // Đăng ký nhận tin nhắn từ Player
        PlayerController.OnHealthChanged += UpdateHPUI;
        PlayerController.OnPlayerDeath += GameOver;
        
        // Reset text lúc đầu
        if(statusText) statusText.text = "";
    }

    void OnDisable()
    {
        // Hủy đăng ký (Bắt buộc)
        PlayerController.OnHealthChanged -= UpdateHPUI;
        PlayerController.OnPlayerDeath -= GameOver;
    }

    void UpdateHPUI(int currentHealth)
    {
        if (hpText != null)
        {
            hpText.text = "HP: " + currentHealth + "%";
            
            // Hiệu ứng đổi màu chữ khi máu thấp (Thêm chút xịn xò)
            if (currentHealth < 30) hpText.color = Color.red;
            else hpText.color = Color.white;
        }
    }

    void GameOver()
    {
        if (statusText != null)
        {
            statusText.text = "GAME OVER";
            statusText.color = Color.red;
            statusText.fontSize = 60;
        }
    }
}