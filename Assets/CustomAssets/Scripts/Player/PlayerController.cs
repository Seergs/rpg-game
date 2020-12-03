using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    private PlayerAnimation _animator;
    [SerializeField]
    private int _gold;
    void Start()
    {
        _animator = GetComponent<PlayerAnimation>();
        _navAgent = GetComponent<NavMeshAgent>();
        _gold = 0;

        if (_animator == null)
        {
            Debug.LogWarning("No se encontró el player animation");
        }

        if (_navAgent == null)
        {
            Debug.LogWarning("No se encontró el nav agent del jugador");
        }
    }   

    void Update()
    {
        float normalizedSpeed = _navAgent.velocity.magnitude / _navAgent.speed;

        _animator.PlayerMove(normalizedSpeed);
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            _animator.PlayerAttack();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            _animator.PlayerSpecialAtack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.PlayerBlock();
        }
    }
    public void UpdateGold(int gold)
    {
        _gold += gold;
    }
}
