using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // 移动速度
    public float jumpForce = 5.0f; // 跳跃力度（向上移动力度）

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // 获取摄像机的前向和右向方向
        Vector3 forward = mainCamera.transform.forward;
        Vector3 right = mainCamera.transform.right;

        forward.y = 0; // 防止人物在垂直方向上移动
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // 获取输入
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 moveDirection = forward * vertical + right * horizontal;

        // 移动人物
        transform.Translate(moveDirection * (moveSpeed * Time.deltaTime), Space.World);

        // 向上移动（不是跳跃）
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.Translate(Vector3.up * (jumpForce * Time.deltaTime), Space.World);
        }
    }
}