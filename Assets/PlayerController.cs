using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    // Mặc định là 10, nhưng nhớ kiểm tra trong Inspector xem có bị chỉnh về 0 không nhé
    public float moveSpeed = 10f; 
    
    public int maxHealth = 100;
    private int currentHealth;
    
    public static event Action<int> OnHealthChanged;
    public static event Action OnPlayerDeath;

    void Start()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth); 
    }

    void Update()
    {
        // 1. Nhận tín hiệu phím
        float h = Input.GetAxis("Horizontal"); // A D
        float v = Input.GetAxis("Vertical");   // W S

        // 2. Tạo vector hướng
        Vector3 direction = new Vector3(h, v, 0);
        
        // 3. Chuẩn hóa để không đi chéo quá nhanh
        if (direction.magnitude > 1) direction.Normalize();

        // 4. DI CHUYỂN (QUAN TRỌNG: Thêm Space.World)
        // Space.World giúp nhân vật đi theo hướng của mặt đất, không bị phụ thuộc vào việc nhân vật đang xoay đi đâu
        transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0) return;

        currentHealth -= damage;
        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            OnPlayerDeath?.Invoke();
            Debug.Log("Player đã hy sinh!");
            gameObject.SetActive(false);
        }
    }
}