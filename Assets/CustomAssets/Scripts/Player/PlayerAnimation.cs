using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _robotAnim;
    
    void Start()
    {
        _robotAnim = GetComponentInChildren<Animator>();
        if (_robotAnim == null)
        {
            Debug.LogWarning("No se encontró el animador del robot");
        }
    }

    public void PlayerMove(float speed)
    {
        _robotAnim.SetFloat("Speed", speed);
    }

    public void PlayerAttack()
    {
        _robotAnim.SetTrigger("isAttacking");
    }
    public void PlayerBlock()
    {
        _robotAnim.SetTrigger("isBlocking"); 
    }

    public void PlayerSpecialAtack()
    {
        _robotAnim.SetTrigger("isSpecialAttacking");
    }
}
