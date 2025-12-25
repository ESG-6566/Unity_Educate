# 1. تعریف میزان پرش
```csharp
    [Range(0f, 15f)]
    [SerializeField] float jumpForce = 5f;
```
<img src="jump-force-in-editor.jpg"/>

# 2. نوشتن تابع پرش

```csharp
private void Jump(InputAction.CallbackContext context)
    {
        Vector3 newVeclocity = rb.linearVelocity;
        newVeclocity.y = jumpForce;
        rb.linearVelocity = newVeclocity;
    }
```
# 3. اضافه کردن به ورودی(input)

```csharp
input.Player.Jump.performed += Jump;
```
