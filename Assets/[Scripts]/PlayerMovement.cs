using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [SerializeField]
    float walkSpeed = 5;

    [SerializeField]
    float runSpeed = 10;

    [SerializeField]
    float jumpForce = 5;


    [Header("Camera Settings")]
    public float mouseSensitivity = 10;

    // References
    Vector2 inputVector = Vector2.zero;
    Vector3 moveDirection = Vector3.zero;
    Vector2 lookInput = Vector2.zero;
    float xRotation = 0f;

    Rigidbody rb;

    public Transform self;
    public Transform camera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    void Start()
    {
        
    }

    void Update()
    {

        //********Movement********//
        if (!(inputVector.magnitude > 0))
        {
            moveDirection = Vector3.zero;
        }

        moveDirection = (transform.forward * inputVector.y) + (transform.right * inputVector.x);
        //float currentSpeed = playerController.isRunning ? runSpeed : walkSpeed;
        float currentSpeed = runSpeed;

        Vector3 movementDirection = moveDirection * (currentSpeed * Time.deltaTime);

        transform.position += movementDirection;

        //********Look********//
        self.Rotate(Vector3.up * lookInput.x);
        //float lookDirection = Mathf.Clamp(lookInput.y, 40, 180);
        //camera.Rotate(Vector3.right * -lookInput.y);
        xRotation -= lookInput.y;
        xRotation = Mathf.Clamp(xRotation, -75, 40);

        camera.localRotation = Quaternion.Euler(xRotation, 0, 0);

    }

    public void OnMove(InputValue value)
    {
        inputVector = value.Get<Vector2>();
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();

    }
}
