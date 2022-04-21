using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private Controller controller;
    private IsDead isdead;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<Controller>();
        isdead = GetComponent<IsDead>();
    }

    public void PlayIdleAnim()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Jumping", false);   
    }
    public void PlayRunAnim()
    {
        animator.SetBool("Jumping", false);
        animator.SetBool("Running", true);   
    }
    public void PlayJumpAnim()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Jumping", true);   
    }
    public void PlayFireAnim()
    {
        animator.SetTrigger("Firing");
    }
    public void PlayDieAnim()
    {
        animator.SetBool("Running", false);
        animator.SetBool("Jumping", false);
        animator.SetTrigger("Dead");
    }

    public void Animations()
    {
        switch (controller.characterStates)
        {
            case Controller.States.Idle:
                PlayIdleAnim();
                break;
            case Controller.States.Jump:
                PlayJumpAnim();
                break;
            case Controller.States.Run:
                PlayRunAnim();
                break;        

            default:
                break;
        }
    }
}
