using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Challenge1
{
  public class PlayerControllerX : MonoBehaviour
  {
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private InputAction _rotateAction;

    void OnEnable()
    {
      _rotateAction.Enable();
    }

    void FixedUpdate()
    {
      Vector2 rotateInput = _rotateAction.ReadValue<Vector2>();
      transform.Translate(Vector3.forward * _speed * Time.deltaTime);
      transform.Rotate(Vector3.left * _rotationSpeed * rotateInput.y * Time.deltaTime);
    }
  }
}