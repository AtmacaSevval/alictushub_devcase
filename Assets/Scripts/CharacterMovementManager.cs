using UnityEngine;

public class CharacterMovementManager : MonoBehaviour
{
    public VariableJoystick joystick;
    public CharacterController Controller;
    public float movementSpeed;
    public float rotationSpeed;

    public Animator playerAnimator;
    public Canvas inputCanvas;
    public bool isJoystick;

    private void Start()
    {
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0.0f, joystick.Direction.y);
            Controller.SimpleMove(movementDirection * movementSpeed);

            if (movementDirection.sqrMagnitude <= 0)
            {
                playerAnimator.SetBool("run", false);
                return;
            }

            playerAnimator.SetBool("run", true);
            var targetDirection = Vector3.RotateTowards(Controller.transform.forward, movementDirection,
                rotationSpeed * Time.deltaTime, 0.0f);
        
            Controller.transform.rotation = Quaternion.LookRotation(targetDirection);
            ;
        }
    }
}
