using UnityEngine;

public class EnemyAnimationManager : MonoBehaviour
{
    private Animator enemyAnimator;

    private void Awake()
    {
        enemyAnimator = GetComponent<Animator>();
    }

    public void PlayEnteredFieldAnimation()
    {
        enemyAnimator.SetTrigger("OnEnteredField");
    }
    
    public void StopEnteredFieldAnimation()
    {
        enemyAnimator.ResetTrigger("OnEnteredField");
    }
    
    public void PlayDeathAnimation()
    {
        StopEnteredFieldAnimation();
        enemyAnimator.SetTrigger("Death");
    }
}

