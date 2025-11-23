using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
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
        Vector2 inputValue = input.Player.Move.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        float newX = currentPosition.x + inputValue.x;
        float newZ = currentPosition.z + inputValue.y;
        Vector3 newPosition = new Vector3(newX, currentPosition.y, newZ);
        transform.position = newPosition;
    }
}
