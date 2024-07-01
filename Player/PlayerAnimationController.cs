using System;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayTriggerJump()
    {
        _animator.SetTrigger("Jump");
    }
    
    public void SetBoolGround(bool state)
    {
        _animator.SetBool("Ground", state);
    }
    
    public void SetTriggerJogLeft()
    {
        _animator.SetTrigger("Jog Left");
    }
    
    public void SetTriggerJogRight()
    {
        _animator.SetTrigger("Jog Right");
    }
    
    public void SetTriggerRoll()
    {
        _animator.SetTrigger("Roll");
    }
    
    public void ResetTriggersJog()
    {
        _animator.ResetTrigger("Jog Right");
        _animator.ResetTrigger("Jog Left");
    }
    
    public void SetTriggerDeath()
    {
        _animator.SetTrigger("Death");
    }
    
    public void SetTriggerRun()
    {
        _animator.SetTrigger("Run");
    }
    
    public void ResetTriggerDeath()
    {
        _animator.ResetTrigger("Death");
    }
}
