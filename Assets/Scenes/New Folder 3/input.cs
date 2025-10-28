using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class input : MonoBehaviour
{
    
 static public PlayerInput  _playerInput;
  private InputAction _moveAction;
  public event Action<Vector2> OnMove;
  private void Awake()
  {
      _playerInput = GetComponent<PlayerInput>();
      _moveAction = _playerInput.actions["Move"];
  }

  private void OnEnable()
  {
      _moveAction.performed += InputVector;
      _moveAction.canceled += InputVector;
  }

  private void OnDisable()
  {
      _moveAction.performed -= InputVector;
      _moveAction.canceled -= InputVector;
  }

  private void InputVector(InputAction.CallbackContext context)
    {
        OnMove?.Invoke(context.ReadValue<Vector2>());
    }
    
    
}
