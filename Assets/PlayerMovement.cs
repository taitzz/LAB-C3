using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 moveDir;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A D
        float v = Input.GetAxis("Vertical");   // W S

        moveDir = new Vector3(h, v, 0);


        // ❗ Normalize để không chạy chéo nhanh
        if (moveDir.magnitude > 1)
        {
            moveDir = moveDir.normalized;
        }

        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,
                        transform.position + moveDir);
    }
}