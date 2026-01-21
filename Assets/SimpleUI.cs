using UnityEngine;
using UnityEngine.UI;

public class SimpleUI : MonoBehaviour
{
    public Text uiText;

    // Hàm này phải là PUBLIC
    public void UpdateHealthUI(int health)
    {
        if (uiText != null)
        {
            uiText.text = "Lab 6 HP: " + health;
        }
    }
    
    // Hàm đổi màu chơi cho vui
    public void ChangeColorWarning(int health)
    {
        if(health < 50 && uiText != null) uiText.color = Color.red;
    }
}