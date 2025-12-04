using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [Range(0f, 100f)]
    [SerializeField] float speed = 5f;
    private InputSystem_Actions input;

    void Awake()
    {
        input = new InputSystem_Actions();
        input.Enable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!input.Player.Move.IsPressed()) return;

        Vector2 inputValue = input.Player.Move.ReadValue<Vector2>();

        float radians = Mathf.Atan2(inputValue.x, inputValue.y);
        Vector3 camEuler = Camera.main.transform.eulerAngles;
        float angle = radians * Mathf.Rad2Deg + camEuler.y;
        transform.rotation = Quaternion.Euler(0, angle, 0);

        float timeAndSpeed = Time.deltaTime * speed;
        Vector3 forwardMove = transform.forward * timeAndSpeed;
        transform.position += forwardMove;

    }
}
