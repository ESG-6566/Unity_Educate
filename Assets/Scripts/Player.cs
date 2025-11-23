using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
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
        Vector2 inputValue = input.Player.Move.ReadValue<Vector2>();
        Vector3 currentPosition = transform.position;
        float timeAndSpeed =  Time.deltaTime * speed;
        float newX = currentPosition.x + inputValue.x * timeAndSpeed;
        float newZ = currentPosition.z + inputValue.y * timeAndSpeed;
        Vector3 newPosition = new Vector3(newX, currentPosition.y, newZ);
        transform.position = newPosition;
    }
}
