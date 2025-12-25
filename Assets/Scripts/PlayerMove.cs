using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] private float speed = 5f;
    [Range(0f, 15f)]
    [SerializeField] private float jumpForce = 5f;
    private InputSystem_Actions input;
    private Rigidbody rb;

    void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
        input.Player.Jump.performed += Jump;

        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {

    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        Move();
    }

    private void Jump(InputAction.CallbackContext context)
    {
        Vector3 newVeclocity = rb.velocity;
        newVeclocity.y = jumpForce;
        rb.velocity = newVeclocity;
    }
    private void Move()
    {
        if (!input.Player.Move.IsPressed()) return;

        Vector2 inputValue = input.Player.Move.ReadValue<Vector2>();

        float radians = Mathf.Atan2(inputValue.x, inputValue.y);
        Vector3 camEuler = Camera.main.transform.eulerAngles;
        float angle = radians * Mathf.Rad2Deg + camEuler.y;
        transform.rotation = Quaternion.Euler(0, angle, 0);

        float timeAndSpeed = Time.fixedDeltaTime * speed;
        Vector3 forwardMove = transform.forward * timeAndSpeed;
        rb.position += forwardMove;
    }
}
