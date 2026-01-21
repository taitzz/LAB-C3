using UnityEngine;
using UnityEngine.UI; // BẮT BUỘC PHẢI CÓ DÒNG NÀY ĐỂ DÙNG UI

public class SignedAngleDemo : MonoBehaviour
{
    public Transform target;      // Kéo Target vào đây
    public Text uiText;           // Kéo cái UI Text vào đây
    public float turnSpeed = 2f;  // Tốc độ xoay

    void Update()
    {
        if (target == null) return;

        // 1. Xác định hướng tới mục tiêu
        Vector3 targetDir = target.position - transform.position;
        
        // 2. Lấy hướng trước mặt của nhân vật
        Vector3 forward = transform.forward;

        // 3. TÍNH SIGNED ANGLE (Phần quan trọng nhất của Lab)
        // Tham số thứ 3 là trục xoay (Vector3.up là trục Y - xoay ngang)
        float angle = Vector3.SignedAngle(forward, targetDir, Vector3.up);

        // 4. Hiển thị lên UI
        if (uiText != null)
        {
            // Làm tròn 2 chữ số thập phân cho đẹp
            uiText.text = "Góc lệch: " + angle.ToString("F2") + " độ";
        }

        // 5. Ứng dụng: Xoay nhân vật dựa trên góc này
        // Nếu góc dương (bên phải) -> xoay phải. Góc âm (bên trái) -> xoay trái.
        // Chúng ta cộng góc này vào trục Y hiện tại để xoay theo.
        
        // Cách xoay đơn giản: Xoay mỗi khung hình một chút theo hướng của angle
        transform.Rotate(0, angle * turnSpeed * Time.deltaTime, 0);
    }
    
    // Vẽ tia để dễ debug
    void OnDrawGizmos()
    {
        if(target != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, transform.position + transform.forward * 5); // Tia hướng mặt
            
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position); // Tia hướng mục tiêu
        }
    }
}