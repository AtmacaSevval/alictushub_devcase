using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private CharacterController controller;
    [SerializeField] private PlayerAnimationManager playerAnimationManager;
    
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    
    [SerializeField] private Canvas inputCanvas;
    
    private bool isJoystickActive;
    
    private PlayerHealth playerHealth;
    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Start()
    {
        ActivateJoystickInput();
    }

    private void Update()
    {
        HandleJoystickMovement();
    }

    private void ActivateJoystickInput()
    {
        isJoystickActive = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void HandleJoystickMovement()
    {
        if (!isJoystickActive || playerHealth.IsDead) return;

        Vector3 movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
        MovePlayer(movementDirection);
        RotatePlayer(movementDirection);
        UpdateAnimation(movementDirection);
    }

    private void MovePlayer(Vector3 direction)
    {
        controller.SimpleMove(direction * movementSpeed);
    }

    
    private void RotatePlayer(Vector3 direction)
    {
        if (direction.sqrMagnitude <= 0) return;

        Vector3 targetDirection = Vector3.RotateTowards(controller.transform.forward, direction,
            rotationSpeed * Time.deltaTime, 0.0f);
        controller.transform.rotation = Quaternion.LookRotation(targetDirection);
    }

    private void UpdateAnimation(Vector3 movementDirection)
    {
        bool isRunning = movementDirection.sqrMagnitude > 0.1f;
        
        playerAnimationManager.SetAnimation(isRunning);
    }
}
