using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class Interactable : MonoBehaviour
{
    protected GameObject interactedObject_;
    protected NavMeshAgent playerAgent_;
    protected PlayerController playerController_;
    private bool _hastInteracted;

    void Start()
    {
        _hastInteracted = true;
    }

    void Update()
    {
        if (playerAgent_ != null && !playerAgent_.pathPending)
        {
            if (playerAgent_.remainingDistance <= playerAgent_.stoppingDistance)
            {
                if (!_hastInteracted)
                {
                Interact();
                    _hastInteracted = true;
                }
            }
        }

    }

    public void GetInteractionValues(PlayerController _playerController, NavMeshAgent playerAgent, GameObject interactedObject)
    {
        playerAgent_ = playerAgent;
        interactedObject_ = interactedObject;
        playerController_ = _playerController;
        _hastInteracted = false;
     }

    public virtual void Interact()
    {
        Debug.Log("Interactuando con un objeto desconocido");
    }
}
