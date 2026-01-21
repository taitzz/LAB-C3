using UnityEngine;

public class LifecycleLogger : MonoBehaviour
{
    // 1. Hàm này chạy đầu tiên khi Script được khởi tạo (kể cả khi chưa active)
    void Awake()
    {
        Debug.Log("1. Awake - " + gameObject.name);
    }

    // 2. Chạy mỗi khi GameObject được Bật (Active)
    void OnEnable()
    {
        Debug.Log("2. OnEnable - " + gameObject.name);
    }

    // 3. Chạy 1 lần duy nhất ngay trước frame đầu tiên
    void Start()
    {
        Debug.Log("3. Start - " + gameObject.name);
    }

    // 4. Chạy liên tục mỗi khung hình (Frame) để xử lý logic vật lý cố định
    void FixedUpdate()
    {
        // Tôi comment lại để tránh spam console quá nhiều. 
        // Muốn thấy log thì bỏ 2 dấu gạch chéo // ở đầu dòng dưới đi nhé.
        // Debug.Log("4. FixedUpdate"); 
    }

    // 5. Chạy liên tục mỗi khung hình (xử lý logic game, input)
    void Update()
    {
        // Debug.Log("5. Update"); // Bỏ comment nếu muốn thấy nó chạy liên tục

        // CHỨC NĂNG HỖ TRỢ TEST LAB:
        
        // Bấm phím SPACE để nhân bản (Instantiate) chính vật thể này
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("--- Đang Instantiate (Tạo mới) ---");
            Instantiate(gameObject, new Vector3(transform.position.x + 1.5f, 0, 0), Quaternion.identity);
        }

        // Bấm phím D để hủy (Destroy) vật thể này
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("--- Đang Destroy (Hủy) ---");
            Destroy(gameObject);
        }
    }

    // 6. Chạy sau khi tất cả các hàm Update đã chạy xong (thường dùng cho Camera theo dõi nhân vật)
    void LateUpdate()
    {
        // Debug.Log("6. LateUpdate");
    }

    // 7. Chạy khi GameObject bị Tắt (Inactive)
    void OnDisable()
    {
        Debug.Log("7. OnDisable - " + gameObject.name);
    }

    // 8. Chạy khi GameObject bị Hủy hoàn toàn khỏi game
    void OnDestroy()
    {
        Debug.Log("8. OnDestroy - " + gameObject.name);
    }
}