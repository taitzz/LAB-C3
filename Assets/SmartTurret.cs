using UnityEngine;

public class SmartTurret : MonoBehaviour
{
    public Transform target;        // Kéo Player vào đây
    public float rotateSpeed = 5f;  // Tốc độ xoay (Dùng Slerp/RotateTowards)
    public float viewRadius = 10f;  // Tầm xa nhìn thấy
    public float viewAngle = 45f;   // Góc nhìn (FOV - Một nửa góc nón)
    
    public int damagePerSecond = 20; // Sát thương gây ra
    private float damageTimer = 0f;

    // Màu sắc để báo hiệu (Visual Feedback)
    private Renderer turRenderer;

    void Start()
    {
        turRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (target == null) return;

        // 1. Tính khoảng cách (Lab 2 - Vector Math)
        float distance = Vector3.Distance(transform.position, target.position);

        // 2. Tính hướng tới mục tiêu
        Vector3 dirToTarget = (target.position - transform.position).normalized;

        // 3. Tính góc lệch (Lab 4 logic, dùng Angle cho đơn giản)
        // Nếu góc giữa hướng mặt (forward) và hướng tới target nhỏ hơn viewAngle
        float angleToTarget = Vector3.Angle(transform.forward, dirToTarget);

        // --- LOGIC AI ---
        // Nếu Player nằm trong Tầm Xa VÀ nằm trong Góc Nhìn
        if (distance <= viewRadius && angleToTarget <= viewAngle)
        {
            // -> PHÁT HIỆN PLAYER
            turRenderer.material.color = Color.red; // Đổi màu cảnh báo
            
            // Xoay nhanh về phía Player (Lab 3)
            Quaternion lookRot = Quaternion.LookRotation(dirToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, rotateSpeed * Time.deltaTime * 2);

            // Gây sát thương theo thời gian
            damageTimer += Time.deltaTime;
            if(damageTimer >= 1f) // Mỗi 1 giây trừ máu 1 lần
            {
                PlayerController player = target.GetComponent<PlayerController>();
                if(player != null) player.TakeDamage(damagePerSecond);
                damageTimer = 0f;
            }
        }
        else
        {
            // -> KHÔNG THẤY PLAYER (Trạng thái Tuần tra/Idle)
            turRenderer.material.color = Color.green; // An toàn
            
            // Xoay từ từ (Lab 3 - RotateTowards)
            // Ở đây tôi cho nó xoay theo Player nhưng chậm hơn, hoặc bạn có thể làm nó xoay vòng tròn
            Quaternion lookRot = Quaternion.LookRotation(dirToTarget);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRot, rotateSpeed * Time.deltaTime * 10);
        }
    }

    // --- VẼ GIZMOS (Để scene trông "xịn" và dễ debug) ---
    void OnDrawGizmos()
    {
        // Vẽ tầm xa (Vòng tròn dây)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        // Vẽ nón tầm nhìn (2 tia giới hạn góc)
        Gizmos.color = Color.blue;
        Vector3 rightDir = Quaternion.Euler(0, viewAngle, 0) * transform.forward;
        Vector3 leftDir = Quaternion.Euler(0, -viewAngle, 0) * transform.forward;
        
        Gizmos.DrawRay(transform.position, rightDir * viewRadius);
        Gizmos.DrawRay(transform.position, leftDir * viewRadius);
    }
}