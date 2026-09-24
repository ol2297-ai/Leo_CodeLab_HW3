using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PLY : MonoBehaviour
{
    public Transform playerCamera;
    public float moveSpeed = 5f;
    public float mouseSensitivity = 2f;
    public float jumpHeight = 1.2f;
    public float gravity = -20f;

    private CharacterController controller;
    private float verticalSpeed;
    private float cameraPitch;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // 鼠标左右转身体，上下转相机
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(Vector3.up * mouseX);
        cameraPitch = Mathf.Clamp(cameraPitch - mouseY, -85f, 85f);
        playerCamera.localRotation = Quaternion.Euler(cameraPitch, 0f, 0f);

        // WASD 移动
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 movement = (transform.right * x + transform.forward * z).normalized;

        if (controller.isGrounded && verticalSpeed < 0f)
            verticalSpeed = -2f;

        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
            verticalSpeed = Mathf.Sqrt(jumpHeight * -2f * gravity);

        verticalSpeed += gravity * Time.deltaTime;
        movement.y = verticalSpeed;

        controller.Move(movement * moveSpeed * Time.deltaTime);
    }
}
