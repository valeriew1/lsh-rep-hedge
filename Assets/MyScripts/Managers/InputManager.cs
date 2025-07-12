using UnityEngine;
using System;

public class InputManager : Singleton<InputManager>
{
    public event Action<Vector2> OnMovementInput;
    public event Action OnJumpPressed;
    public event Action OnJumpReleased;
    public event Action OnInteractPressed;
    public event Action OnPausePressed;
    public event Action<Vector2> OnMousePositionChanged;
    public event Action OnLeftClickPressed;
    public event Action OnLeftClickReleased;
    public event Action OnRightClickPressed;
    public event Action OnRightClickReleased;
    
    [Header("Настройки ввода")]
    public float mouseSensitivity = 1f;
    public bool invertYAxis = false;
    
    private Vector2 movementInput;
    private Vector2 mousePosition;
    
    public Vector2 MovementInput => movementInput;
    public Vector2 MousePosition => mousePosition;
    
    protected override void Awake()
    {
        base.Awake();
    }
    
    void Update()
    {
        HandleMovementInput();
        HandleActionInput();
        HandleMouseInput();
    }
    
    public Vector2 GetMouseDelta()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        if (invertYAxis)
            mouseY = -mouseY;
            
        return new Vector2(mouseX, mouseY);
    }
    
    public bool IsMoving()
    {
        return movementInput != Vector2.zero;
    }
    
    public Vector3 GetMovementDirection(Transform cameraTransform)
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;
        
        forward.y = 0f;
        right.y = 0f;
        forward.Normalize();
        right.Normalize();
        
        return forward * movementInput.y + right * movementInput.x;
    }

    public bool IsSprintHeld()
    {
        return Input.GetKey(KeyCode.LeftShift);
    }
    
    public bool IsCrouchHeld()
    {
        return Input.GetKey(KeyCode.LeftControl);
    }
    
    void HandleMovementInput()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        movementInput = new Vector2(horizontal, vertical).normalized;
        
        if (movementInput != Vector2.zero)
        {
            OnMovementInput?.Invoke(movementInput);
        }
    }
    
    void HandleActionInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteractPressed?.Invoke();
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            OnPausePressed?.Invoke();
        }
    }
    
    void HandleMouseInput()
    {
        mousePosition = Input.mousePosition;
        OnMousePositionChanged?.Invoke(mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            OnLeftClickPressed?.Invoke();
        }
        
        if (Input.GetMouseButtonUp(0))
        {
            OnLeftClickReleased?.Invoke();
        }
        
        if (Input.GetMouseButtonDown(1))
        {
            OnRightClickPressed?.Invoke();
        }
        if (Input.GetMouseButtonUp(1))
        {
            OnRightClickReleased?.Invoke();
        }
    }
}