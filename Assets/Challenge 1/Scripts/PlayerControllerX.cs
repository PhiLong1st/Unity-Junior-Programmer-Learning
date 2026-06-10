using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;

    public InputAction rotateAction;

    void OnEnable()
    {
        rotateAction.Enable();
    }

    void FixedUpdate()
    {
        Vector2 rotateInput = rotateAction.ReadValue<Vector2>();
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(Vector3.left * rotationSpeed * rotateInput.y * Time.deltaTime);
    }
}
