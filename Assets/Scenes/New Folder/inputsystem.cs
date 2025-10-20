using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class inputsystem : MonoBehaviour
{
    private PlayerInput playerInput;
    private InputAction inputAction;
    public event Action<int> selected;
    

    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        inputAction = playerInput.actions["Navigate"];
    }

    void OnEnable()
    {
        // performed にメソッドを登録
        inputAction.performed += OnSelected;
    }

    void OnDisable()
    {
        // 登録解除（重要！）
        inputAction.performed -= OnSelected;
        
        
    }

    private void OnSelected(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        int moveY = Mathf.RoundToInt(context.ReadValue<Vector2>().y);

        // 上を -1、下を +1 にしたい場合
        selected?.Invoke(-moveY);
        

        Debug.Log($"Move入力検知: {moveY}");
    }
}
