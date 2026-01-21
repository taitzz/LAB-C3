using UnityEngine;
using UnityEngine.Events; // BẮT BUỘC CÓ

public class PlayerEventLab6 : MonoBehaviour
{
    // 1. Định nghĩa kiểu Event có tham số int (để truyền máu)
    // Phải có [System.Serializable] thì Unity mới hiện ra ngoài
    [System.Serializable]
    public class HealthEvent : UnityEvent<int> { }

    // 2. Khai báo biến Event ra ngoài Inspector
    public HealthEvent OnHealthChanged;

    public int currentHealth = 100;

    void Update()
    {
        // Bấm K để thử trừ máu
        if (Input.GetKeyDown(KeyCode.K))
        {
            TakeDamage(10);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Máu còn: " + currentHealth);

        // 3. PHÁT SÓNG (Invoke)
        // Gọi tất cả những ai đã được gắn vào list trong Inspector
        OnHealthChanged?.Invoke(currentHealth);
    }
}