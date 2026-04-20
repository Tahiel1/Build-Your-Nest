using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Input Actions")]
    [SerializeField] private float acceleration = 8f;
    [SerializeField] private float deceleration = 6f;
    [SerializeField] private float maxSpeed = 6f;
    [SerializeField] private float rotationSpeed = 200f;

    [Header("Input Actions")]
    [SerializeField] private InputActionAsset PlayerContorls;

    private Rigidbody2D rb;
    private float currentSpeed = 0f;

    private InputAction moveAction;
    private InputAction rotateAction;
    private float moveInput;
    private float rotateInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = PlayerContorls.FindActionMap("Player").FindAction("Move");
        rotateAction = PlayerContorls.FindActionMap("Player").FindAction("rotate");

        moveAction.performed += context => moveInput = context.ReadValue<float>();
        moveAction.canceled += context => moveInput = 0;

        rotateAction.performed += context => rotateInput = context.ReadValue<float>();
        rotateAction.canceled += context => rotateInput = 0;
    }

    private void OnEnable()
    {
        moveAction.Enable();
        rotateAction.Enable();
    }
    private void OnDisable()
    {
        moveAction.Disable();
        rotateAction.Disable();
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleRotation();
    }


    void HandleMovement()
    {

        currentSpeed += moveInput * acceleration * Time.fixedDeltaTime;

        currentSpeed = Mathf.Clamp(currentSpeed, -maxSpeed/2, maxSpeed);

        Vector2 direction = transform.up;
        rb.linearVelocity = direction * currentSpeed;
    }

    void HandleRotation()
    {
        float rotation = rotateInput * rotationSpeed * Time.fixedDeltaTime;
        rb.MoveRotation(rb.rotation - rotation);
    }
}
