using UnityEngine;

public class TurretController : MonoBehaviour
{
    public Transform target;          // Kéo vật thể Target vào đây
    public float rotationSpeed = 50f; // Tốc độ xoay (độ/giây)
    public bool useSmoothRotation = true; // Check vào để xoay mượt, bỏ check để xoay cứng

    void Update()
    {
        // Nếu không có mục tiêu thì không làm gì cả
        if (target == null) return;

        if (useSmoothRotation)
        {
            // --- CÁCH 2: XOAY MƯỢT (RotateTowards) ---
            // Bước 1: Xác định vector hướng từ mình đến mục tiêu
            Vector3 direction = target.position - transform.position;

            // Bước 2: Tính toán xem "góc quay nào" sẽ nhìn về hướng đó
            // Quaternion.LookRotation sẽ trả về góc quay cần thiết
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Bước 3: Xoay từ từ góc hiện tại sang góc đích
            // RotateTowards(góc hiện tại, góc đích, tốc độ tối đa mỗi khung hình)
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else
        {
            // --- CÁCH 1: XOAY NGAY LẬP TỨC (LookAt) ---
            // Lệnh này ép vật thể nhìn ngay vào mục tiêu trong 1 frame
            transform.LookAt(target);
        }
    }
    
    // Vẽ đường đỏ nối tới mục tiêu để dễ debug
    void OnDrawGizmos()
    {
        if(target != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, target.position);
        }
    }
}