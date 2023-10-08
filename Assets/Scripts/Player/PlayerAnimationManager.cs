using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }
    public void PlayDeathAnimation()
    {
        playerAnimator.SetTrigger("Death");
    }

    public void SetAnimation(bool isRunning)
    {
        if (isRunning)
        {
            SetRunAnimation();
        }
        else
        {
            SetIdleAnimation();
        }
    }
    private void SetRunAnimation()
    {
        playerAnimator.SetBool("run", true);
    }
    
    private void SetIdleAnimation()
    {
        playerAnimator.SetBool("run", false);
    }
}
