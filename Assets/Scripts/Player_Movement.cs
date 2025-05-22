using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public bool isGrounded = true;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Chỉ lấy input trục X để di chuyển trái/phải
        float moveX = moveInput.x;

        // Giữ vận tốc Y hiện tại (cho nhảy/rơi)
        float moveY = rb.velocity.y;

        // Tạo vector vận tốc mới
        Vector2 newVelocity = new Vector2(moveX * moveSpeed, moveY);

        // Áp dụng vận tốc
        rb.velocity = newVelocity;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        // Chuẩn hóa vector input để tốc độ không đổi khi di chuyển chéo
        moveInput = moveInput.normalized;
    }
}